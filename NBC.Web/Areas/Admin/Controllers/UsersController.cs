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
        public UsersController(UserService UserService, SettingService settingService, RoleService roleService, UserInRoleService userInRoleService
            , SVService svService)
        {
            this.UserService = UserService;
            this.settingService = settingService;
            this.RoleService = roleService;
            this.UserInRoleService = userInRoleService;
            this.SVService = svService;
        }
        public ActionResult Index()
        {
            return View(UserService.All());
        }
        public ActionResult Details(int? id)
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
        public ActionResult Create()
        {


            return View();
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
                        User thisUser = model;
                        Role role = RoleService.GetRoleByName("Subscribers");
                        UserInRole inRole = new UserInRole();
                        inRole.User = thisUser;
                        inRole.Role = role;
                        NBC.Models.SV thisSV = SVService.Find(9);
                        //inRole.WorkAt = thisSV;
                        inRole.isEnable = true;
                        //inRole.CreatedDate = DateTime.Now;
                        //inRole.ModifiedDate = DateTime.Now;


                        UserInRoleService.Add(inRole);
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
        public ActionResult DeleteConfirmed(int id)
        {
            User user = UserService.Find(id);

            try
            {
               
                var thisUser = new ApplicationUser { UserName = user.UserName, Email = user.Email };
                UserManager.Delete(thisUser);
                UserService.Remove(user);
                UserService.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return PartialView(user);
            }

        }
        public ActionResult AddUserInRole(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<UserInRole> userInRole = UserInRoleService.GetUserInRoleByUserId(id);
            if (userInRole == null)
            {
                return HttpNotFound();
            }
            var role = RoleService.All().ToList();
            ViewBag.role = role;
            return PartialView(userInRole);
        }
        [HttpPost]
        public ActionResult SaveUserInRole(int id, string UserRole_Id)
        {

            List<UserInRole> userInRole = UserInRoleService.GetUserInRoleByUserId(id);
            if (userInRole == null)
            {
                return HttpNotFound();
            }

            UserInRole inRole = new UserInRole();
            inRole.User.Id = id;
            inRole.Role.Id = Convert.ToInt32(UserRole_Id);
            inRole = UserInRoleService.Add(inRole);
            if (inRole == null)
            {
                return Content("UserName ที่ท่านกำลังกำหนดสิทธิ์ มีสิทธิ์นี้ในระบบแล้ว");
            }
            else
            {
                return Content("OK");
            }


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
                userInRole = UserInRoleService.Remove(userInRole);
                return Content("Ok");
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

    }
}