using NBC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NBC.Web.Models;
using System.Threading.Tasks;
using NBC.Models;
using System.Net;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Data;

namespace NBC.Web.Areas.Admin.Controllers
{

    public class UsersController : Controller
    {
        // GET: Admin/Users
        private UserService UserService;
        private SettingService settingService;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private RoleService RoleService;
        private UserInRoleService UserInRoleService;
        private SVService SVService;
        private UnitService UnitService;
       
        public UsersController(UserService UserService, SettingService settingService, RoleService roleService, UserInRoleService userInRoleService
            , SVService svService, UnitService unitService)
        {
            this.UserService = UserService;
            this.settingService = settingService;
            this.RoleService = roleService;
            this.UserInRoleService = userInRoleService;
            this.SVService = svService;
            this.UnitService = unitService;
        }
        public ActionResult Index()
        {
            return View(UserService.All());
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = UserService.Find(id);
            var thisUser = await UserManager.FindByNameAsync(user.UserName);
            string password = thisUser.PasswordHash;
            //  ViewBag.Password = base64Decode(password);
            if (user == null)
            {
                return HttpNotFound();
            }
            return PartialView(user);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = UserService.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return PartialView(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(unit).State = EntityState.Modified;               
                UserService.SetModified(user);
                UserService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public ActionResult Create()
        {


            return PartialView();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User model)
        {
            if (ModelState.IsValid)
            {
                User thisItem = UserService.GetUserByUserName(model.UserName);
                if (thisItem == null)
                {
                    string password = "nBc@1234";
                    var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                    var result = await UserManager.CreateAsync(user, password);

                    if (result.Succeeded)
                    {
                        // await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                        // Send an email with this link
                        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                        // UserService.Add(model);
                        model.isEnable = true;

                        User thisUser = model;
                        Role role = RoleService.GetRoleByName("Subscribers");
                        UserInRole inRole = new UserInRole();
                        inRole.User = thisUser;                        
                        inRole.isEnable = true;
                        
                        inRole.Role = role;
                        inRole = UserInRoleService.Add(inRole);
                       
                        UserInRoleService.SaveChanges();
                        return RedirectToAction("Index");

                    }
                    else
                    {

                        string Error = "อีเมลล์:" + model.Email + " มีในระบบแล้ว กรุณาตรวจสอบอีกครั้ง";
                        ModelState.AddModelError("error", Error);
                    }
                    // AddErrors(result);
                }
                else
                {

                    string Error = "UserName:" + model.UserName + " มีในระบบแล้ว กรุณาตรวจสอบอีกครั้ง";
                    ModelState.AddModelError("error", Error);
                    // throw new Exception("รหัสผู้ใช้นี้มีอยู่ในระบบแล้ว กรุณาตรวจสอบอีกครั้ง");

                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = UserService.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return PartialView(user);
        }

        // POST: Admin/Years/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = UserService.Find(id);

            try
            {

                var thisUser = await UserManager.FindByNameAsync(user.UserName);
                if (user == null)
                {
                    return HttpNotFound();
                }
                var result = await UserManager.DeleteAsync(thisUser);
                //   var roles =  UserInRoleService.GetUserInRoleByUserId(user.Id);
                //foreach(var role in roles)
                //{
                //    UserInRoleService.Remove(role);
                //    UserInRoleService.SaveChanges();
                //}

                UserService.Remove(user);
                UserService.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return PartialView(user);
            }

        }
        public ActionResult AddUserInRole(int id)
        {

            User user = UserService.GetUserById(id);

            // List<UserInRole> userInRole = UserInRoleService.GetUserInRoleByUserId(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var role = RoleService.All().ToList();
            ViewBag.role = role;
            return PartialView(user);
        }
        [HttpPost]
        public ActionResult SaveUserInRole(int id, string UserRole_Id,string WID,string roleName)
        {

            UserInRole userInRole = UserInRoleService.GetUserInRoleByUserIdAndUserRoleId(id, Convert.ToInt32(UserRole_Id));
            if (userInRole != null)
            {
                return HttpNotFound();
            }
           // int WID = ViewBag.WID;
            userInRole = new UserInRole();
            Role role = RoleService.GetUserRoleById(Convert.ToInt32(UserRole_Id));
            User user = UserService.GetUserById(id);
           
           
            userInRole.User = user;
            userInRole.Role = role;
            if (roleName == "SV")
            {
                NBC.Models.SV sv = SVService.GetWorkAtSV(Convert.ToInt32(WID));
                userInRole.WorkAt = sv;
            }
            else if (roleName == "Unit") {
                NBC.Models.Unit unit = UnitService.GetWorkAtUnit(Convert.ToInt32(WID));
                userInRole.WorkAt = unit;
            }
            
            userInRole = UserInRoleService.Add(userInRole);
            UserInRoleService.SaveChanges();
            
            return Content("OK");
           
        }
        [HttpPost]
        public ActionResult DeleteUserInRole(int id)
        {

            UserInRole userInRole = UserInRoleService.Find(id);
            if (userInRole == null)
            {
                return Content("ไม่เจอข้อมูลที่ท่านต้องการจะลบ");
            }
            else
            {
                try
                {
                    UserInRoleService.Remove(userInRole);
                    UserInRoleService.SaveChanges();

                    return Content("OK");
                }
                catch (Exception ex)
                {

                    return Content(ex.ToString());
                }

            }

        }
        [HttpPost]
        public ActionResult SetEnableUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                User user = UserService.Find(id);
                if (user.isEnable == true)
                {
                    user.isEnable = false;
                }
                else
                {
                    user.isEnable = true;
                }
                UserService.SetModified(user);
                UserService.SaveChanges();
                return RedirectToAction("Index");
                // return this.Json(new { success = true });
            }
            catch (System.Exception)
            {

                return this.Json(new { success = false });
            }



        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        [HttpGet]
        public ActionResult DDLWorkAtList(int id)
        {
            Role role = RoleService.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            switch (role.RoleName)
            {
                case "SV":
                    List<NBC.Models.SV> sv = SVService.All().ToList();
                    return Json(sv, JsonRequestBehavior.AllowGet);

                case "Unit":
                    List<NBC.Models.Unit> unit = UnitService.All().ToList();
                    return Json(unit, JsonRequestBehavior.AllowGet);
                default:
                    return View();
                    ;
            }
        }


    }
}