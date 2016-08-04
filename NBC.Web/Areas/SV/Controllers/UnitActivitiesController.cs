using NBC.Models;
using NBC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NBC.Web.Areas.SV.ViewModels;
namespace NBC.Web.Areas.SV.Controllers
{
    
    public class UnitActivitiesController : Controller
    {
        private RoleService RoleService;
        private UserInRoleService UserInRoleService;
        private SVService SVService;
        private UnitService UnitService;
        private YearService YearService;
        private SVUnitYearService SVUnitYearService;
        private UserService UserService;
        private SVActivityYearService SVActivityYearService;
        private UnitActivityService UnitActivityService;
        private SettingService settingService;
        public UnitActivitiesController(RoleService roleService, UserInRoleService userInRoleService, YearService yearService, SVUnitYearService sVUnitYearService
               , SVService svService, UnitService unitService, UserService userService, SVActivityYearService sVActivityYearService, UnitActivityService unitActivityService,
            SettingService settingService)
        {

            this.RoleService = roleService;
            this.UserInRoleService = userInRoleService;
            this.SVService = svService;
            this.UnitService = unitService;
            this.YearService = yearService;
            this.SVUnitYearService = sVUnitYearService;
            this.UserService = userService;
            this.SVActivityYearService = sVActivityYearService;
            this.UnitActivityService = unitActivityService;
            this.settingService = settingService;
        }
        // GET: SV/UnitActivities
        public ActionResult Index()
        {
            var currentYear = settingService.Current.CurrentYearId;
            var year = currentYear;
           
            ViewBag.Y = currentYear;
            var WA_ID = UserWorkat();
            var sv = SVService.Find(WA_ID);
            ViewBag.SV = sv.Name;
            var unitActi = UnitActivityService.getUnitActivityBySvIDYearID(WA_ID,Convert.ToInt32(year));
            var x = 0;
            List<UnitActivityViewModel> unitAc = new List<UnitActivityViewModel>();
            foreach (var item in unitActi)
            {
                var act = SVActivityYearService.Find(item.SVActivityYear_Id);
                var unitActiModel = new UnitActivityViewModel();
                if (unitAc.Count > 0)
                {

                    foreach (var vmItem in unitAc.ToList())
                    {

                        if (vmItem.Unit_ID == item.Unit_Id)
                        {
                            if (item.SVActivityYear.ActitivityType_Id == "NBC")
                            {
                                vmItem.NBCTarget = item.Target;
                            }
                            else if (item.SVActivityYear.ActitivityType_Id == "INCU")
                            {
                                vmItem.INCUTarget = item.Target;
                            }
                            x = item.Unit_Id;
                        }
                        else
                        {
                            if (x != item.Unit_Id)
                            {
                                if (act.ActitivityType_Id == "NBC") { unitActiModel.INCUTarget = item.Target; }
                                if (act.ActitivityType_Id == "INCU") { unitActiModel.INCUTarget = item.Target; }
                                unitActiModel.SVActivityYear_Id = act.Id;
                                unitActiModel.SV_ID = act.SV.Id;
                                unitActiModel.Unit_ID = item.Unit_Id;
                                unitActiModel.Year_ID = act.Year_Id;
                                unitActiModel.UnitName = item.Unit.Name;
                                unitActiModel.SVName = act.SV.Name;
                                unitAc.Add(unitActiModel);
                                x = item.Unit_Id;

                            }


                        }

                    }

                }
                else
                {

                    if (act.ActitivityType_Id == "NBC") { unitActiModel.INCUTarget = item.Target; }
                    if (act.ActitivityType_Id == "INCU") { unitActiModel.INCUTarget = item.Target; }
                    unitActiModel.SVActivityYear_Id = act.Id;
                    unitActiModel.SV_ID = act.SV.Id;
                    unitActiModel.Unit_ID = item.Unit_Id;
                    unitActiModel.Year_ID = act.Year_Id;
                    unitActiModel.UnitName = item.Unit.Name;
                    unitActiModel.SVName = act.SV.Name;
                    unitAc.Add(unitActiModel);
                }







            }
            return View(unitAc);
        }
        [HttpPost]
        public ActionResult Index(int? id)
        {
            var currentYear = settingService.Current.CurrentYearId;
            var year = currentYear;
            if (id != null) {
                year = id;
            }
            ViewBag.Y = currentYear;
            var WA_ID = UserWorkat();
            var sv = SVService.Find(WA_ID);
            ViewBag.SV = sv.Name;
            var unitActi = UnitActivityService.getUnitActivityBySvIDYearID(WA_ID, Convert.ToInt32(year));
            var x = 0;
            List <UnitActivityViewModel> unitAc = new List<UnitActivityViewModel>();
            foreach (var item in unitActi) {
                var act = SVActivityYearService.Find(item.SVActivityYear_Id);
                var unitActiModel = new UnitActivityViewModel();
                if (unitAc.Count > 0)
                {

                    foreach (var vmItem in unitAc.ToList())
                    {

                        if (vmItem.Unit_ID == item.Unit_Id)
                        {
                            if (item.SVActivityYear.ActitivityType_Id == "NBC")
                            {
                                vmItem.NBCTarget = item.Target;
                            }
                            else if (item.SVActivityYear.ActitivityType_Id == "INCU")
                            {
                                vmItem.INCUTarget = item.Target;
                            }
                            x = item.Unit_Id;
                        }
                        else
                        {
                            if (x != item.Unit_Id)
                            {
                                if (act.ActitivityType_Id == "NBC") { unitActiModel.INCUTarget = item.Target; }
                                if (act.ActitivityType_Id == "INCU") { unitActiModel.INCUTarget = item.Target; }
                                unitActiModel.SVActivityYear_Id = act.Id;
                                unitActiModel.SV_ID = act.SV.Id;
                                unitActiModel.Unit_ID = item.Unit_Id;
                                unitActiModel.Year_ID = act.Year_Id;
                                unitActiModel.UnitName = item.Unit.Name;
                                unitActiModel.SVName = act.SV.Name;
                                unitAc.Add(unitActiModel);
                                x = item.Unit_Id;

                            }


                        }

                    }

                }
                else
                {

                    if (act.ActitivityType_Id == "NBC") { unitActiModel.INCUTarget = item.Target; }
                    if (act.ActitivityType_Id == "INCU") { unitActiModel.INCUTarget = item.Target; }
                    unitActiModel.SVActivityYear_Id = act.Id;
                    unitActiModel.SV_ID = act.SV.Id;
                    unitActiModel.Unit_ID = item.Unit_Id;
                    unitActiModel.Year_ID = act.Year_Id;
                    unitActiModel.UnitName = item.Unit.Name;
                    unitActiModel.SVName = act.SV.Name;
                    unitAc.Add(unitActiModel);
                }


               
               
                          
                

            }
            
            return Json(unitAc, JsonRequestBehavior.AllowGet);
        }

        // GET: SV/UnitActivities/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SV/UnitActivities/Create
        public ActionResult Create()
        {
            UnitActivityViewModel UnitActivity = new UnitActivityViewModel();

            return PartialView(UnitActivity);
        }

        // POST: SV/UnitActivities/Create
        [HttpPost]
        public ActionResult Create(UnitActivityViewModel UnitActivityViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                UnitActivity thisUnitActivity = new UnitActivity();
                var WA_ID = UserWorkat();
                var unit = UnitService.Find(UnitActivityViewModel.Unit_ID);                           

                var acti = SVActivityYearService.getSVActivityYearBySVid(WA_ID, UnitActivityViewModel.Year_ID);
                if (acti.Count == 0) {
                  ModelState.AddModelError("error","ในปีงบประมาณ"+ UnitActivityViewModel.Year_ID +"ที่ท่านเลือก ยังไม่ได้กำหนดเป้าหมายในปีกรุณาแจ้งผู้ดูแลระบบ");
                  return View(UnitActivityViewModel);
                }
                foreach (var item in acti) {
                    if (item.ActitivityType_Id == "NBC") {thisUnitActivity.Target = UnitActivityViewModel.NBCTarget;}
                    if (item.ActitivityType_Id == "INCU") { thisUnitActivity.Target = UnitActivityViewModel.INCUTarget; }
                    var svcti = SVActivityYearService.Find(item.Id);
                    thisUnitActivity.SVActivityYear_Id = item.Id;
                    thisUnitActivity.Unit = unit;
                    UnitActivityService.Add(thisUnitActivity);
                    UnitActivityService.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SV/UnitActivities/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SV/UnitActivities/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditTarget(int Id, string NBCTarget, string INCUTarge, string Year)
        {
            var WA_ID = UserWorkat();
            var sVYear = UnitActivityService.getUnitActivityBySvIDUnitIDYearID(Id, Convert.ToInt32(WA_ID), Convert.ToInt32(Year));

            try
            {
                foreach (var item in sVYear)
                {
                    UnitActivity thisUnitAc = UnitActivityService.Find(item.Id);
                    if (item.SVActivityYear.ActitivityType_Id == "NBC") { thisUnitAc.Target = Convert.ToInt32(NBCTarget); }
                    if (item.SVActivityYear.ActitivityType_Id == "INCU") { thisUnitAc.Target = Convert.ToInt32(INCUTarge); }
                    UnitActivityService.SetModified(thisUnitAc);
                    UnitActivityService.SaveChanges();

                }
                return Content("OK");
                // return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return Content("NotOK");

                //return RedirectToAction("Index");
            }




        }
        // GET: SV/UnitActivities/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SV/UnitActivities/Delete/5
        [HttpPost]

        public ActionResult DeleteConfirmed(int id, string Year)
        {
            try
            {
                var WA_ID = UserWorkat();
                var unit = UnitActivityService.getUnitActivityBySvIDUnitIDYearID(id, Convert.ToInt32(WA_ID), Convert.ToInt32(Year));
                foreach (var item in unit)
                {
                    UnitActivity unitActivity = UnitActivityService.Find(item.Id);
                    UnitActivityService.Remove(unitActivity);
                    UnitActivityService.SaveChanges();

                }
                return Content("OK");
            }
            catch (Exception)
            {

                return Content("NotOK");
            }


        }
        [HttpGet]

        public ActionResult DDLYear()
        {
            var years = YearService.GetYear();
            if (years == null)
            {
                return HttpNotFound();
            }
            return Json(years, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DDLUnits(int id)
        {
            var WA_ID = UserWorkat();
            var SvUnitYear = SVUnitYearService.getUnitBySV_IDAndYear_ID(WA_ID,id);
            var unit = SvUnitYear;
            if (unit == null)
            {
                return HttpNotFound();
            }
            return Json(unit, JsonRequestBehavior.AllowGet);
        }
        private int UserWorkat() {
            var Roles = UserService.GetRoles();
            var WA_ID = 0;
            foreach (var role in Roles)
            {
                if (role.Role.RoleName == "SV")
                {
                    WA_ID = role.WorkAt.Id;
                }
            }
            return WA_ID;
        }
    }
}
