using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NBC.DataAccess.Contexts;
using NBC.Models;
using NBC.Services;
using NBC.Web.Areas.Admin.ViewModels;

namespace NBC.Web.Areas.Admin.Controllers
{
    public class SVActivityYearsController : Controller
    {
        private SVActivityYearService svActivityYearService;       
        private YearService YearService;
        private SVService SVService;
        private ActivityTypeService ActivityTypeService;
        private SettingService settingService;

        public SVActivityYearsController(SVActivityYearService service, YearService yearService, SVService svService, ActivityTypeService activityTypeService, SettingService settingService)
        {
            this.svActivityYearService = service;
            this.YearService = yearService;
            this.SVService = svService;
            this.ActivityTypeService = activityTypeService;
            this.settingService = settingService;
        }

        // GET: Admin/SVActivityYears
       
        public ActionResult Index()
        {
            var currentYear = settingService.Current.CurrentYearId;
            var year = currentYear;
            ViewBag.Y = currentYear;
            //if (id != null) {
            //    year = id;
            //}
            var vm = new List<SVActivityYearsIndexVM>();
          
           // 
            var x = 0;
            foreach (var item in svActivityYearService.getSVActivityYearByYear(Convert.ToInt32(year)))
            {

                //todo 
                
                var thisVM = new SVActivityYearsIndexVM();
                if (vm.Count > 0)
                {
                    
                    foreach (var vmItem in vm.ToList()) {
                       
                        if (vmItem.SV_ID == item.SV.Id)
                        {
                            if (item.ActitivityType_Id == "NBC")
                            {
                                vmItem.NBCTarget = item.Target;
                            }
                            else if (item.ActitivityType_Id == "INCU")
                            {
                                vmItem.INCUTarget = item.Target;
                            }
                            x = item.SV.Id;
                        }
                        else {
                            if (x != item.SV.Id)
                            {
                                thisVM.SV_ID = item.SV.Id;
                                thisVM.SVName = item.SV.Name;
                                // thisVM.INCUSVACT_ID = item.ActitivityType_Id;
                                if (item.ActitivityType_Id == "NBC")
                                {
                                    thisVM.NBCTarget = item.Target;
                                }
                                else if (item.ActitivityType_Id == "INCU")
                                {
                                    thisVM.INCUTarget = item.Target;
                                }

                                vm.Add(thisVM);
                                x = item.SV.Id;

                            }
                           
                            
                        }

                    }

                }
                else {
                  

                    thisVM.SV_ID = item.SV.Id;
                    thisVM.SVName = item.SV.Name;
                    // thisVM.INCUSVACT_ID = item.ActitivityType_Id;
                    if (item.ActitivityType_Id == "NBC")
                    {
                        thisVM.NBCTarget = item.Target;
                    }
                    else if (item.ActitivityType_Id == "INCU")
                    {
                        thisVM.INCUTarget = item.Target;
                    }

                    vm.Add(thisVM);
                }             
               




            }
            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(int? id)
        {
            var currentYear = settingService.Current.CurrentYearId;
            var year = currentYear;
            ViewBag.Y = currentYear;
            if (id != null)
            {
                year = id;
            }
            var vm = new List<SVActivityYearsIndexVM>();

            // 
            var x = 0;
            foreach (var item in svActivityYearService.getSVActivityYearByYear(Convert.ToInt32(year)))
            {

                //todo 

                var thisVM = new SVActivityYearsIndexVM();
                if (vm.Count > 0)
                {

                    foreach (var vmItem in vm.ToList())
                    {

                        if (vmItem.SV_ID == item.SV.Id)
                        {
                            if (item.ActitivityType_Id == "NBC")
                            {
                                vmItem.NBCTarget = item.Target;
                            }
                            else if (item.ActitivityType_Id == "INCU")
                            {
                                vmItem.INCUTarget = item.Target;
                            }
                            x = item.SV.Id;
                        }
                        else
                        {
                            if (x != item.SV.Id)
                            {
                                thisVM.SV_ID = item.SV.Id;
                                thisVM.SVName = item.SV.Name;
                                // thisVM.INCUSVACT_ID = item.ActitivityType_Id;
                                if (item.ActitivityType_Id == "NBC")
                                {
                                    thisVM.NBCTarget = item.Target;
                                }
                                else if (item.ActitivityType_Id == "INCU")
                                {
                                    thisVM.INCUTarget = item.Target;
                                }

                                vm.Add(thisVM);
                                x = item.SV.Id;

                            }


                        }

                    }

                }
                else
                {


                    thisVM.SV_ID = item.SV.Id;
                    thisVM.SVName = item.SV.Name;
                    // thisVM.INCUSVACT_ID = item.ActitivityType_Id;
                    if (item.ActitivityType_Id == "NBC")
                    {
                        thisVM.NBCTarget = item.Target;
                    }
                    else if (item.ActitivityType_Id == "INCU")
                    {
                        thisVM.INCUTarget = item.Target;
                    }

                    vm.Add(thisVM);
                }





            }
            return Json(vm, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/SVActivityYears/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SVActivityYear sVActivityYear = svActivityYearService.Find(id);
            if (sVActivityYear == null)
            {
                return HttpNotFound();
            }
            return View(sVActivityYear);
        }

        // GET: Admin/SVActivityYears/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Admin/SVActivityYears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NBC.Web.Areas.Admin.ViewModels.SVActivityYearsIndexVM sVActivityYear)
        {
            try
            {
               
                
                //for (int i = 1; i <= ActivityTypeService.All().Count(); i++) {

                //}
                foreach (var item in ActivityTypeService.All().ToList()) {
                    SVActivityYear thisSVAc = new SVActivityYear();
                    NBC.Models.ActivityType ac=null;
                    if (item.Id == "NBC") {
                        thisSVAc.Target = sVActivityYear.NBCTarget;
                        ac = ActivityTypeService.Find("NBC");
                        thisSVAc.ActitivityType_Id = "NBC";
                    }

                    if (item.Id == "INCU") {
                        thisSVAc.Target = sVActivityYear.INCUTarget;
                         ac = ActivityTypeService.Find("INCU");
                        thisSVAc.ActitivityType_Id = "INCU";
                    }

                    NBC.Models.SV sv = SVService.Find(sVActivityYear.SV_ID);                   
                    NBC.Models.Year year = YearService.Find(sVActivityYear.Year_ID);

                    thisSVAc.Year_Id = sVActivityYear.Year_ID;                    
                    thisSVAc.SV = sv;
                    thisSVAc.Year = year;
                    thisSVAc.ActitivityType = ac;

                    svActivityYearService.Add(thisSVAc);
                    svActivityYearService.SaveChanges();
                }
               
                return RedirectToAction("Index");
            }
            catch 
            {

               
            }


            return View(sVActivityYear);

        }

        // GET: Admin/SVActivityYears/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SVActivityYear sVActivityYear = svActivityYearService.Find(id);
            if (sVActivityYear == null)
            {
                return HttpNotFound();
            }
            return View(sVActivityYear);
        }

        // POST: Admin/SVActivityYears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditTarget(int Id, string NBCTarget, string INCUTarge, string Year)
        {
            var sVYear = svActivityYearService.getSVActivityYearBySVid(Id,Convert.ToInt32(Year));

            try
            {
                foreach (var item in sVYear) {
                    SVActivityYear thisSVAc = svActivityYearService.Find(item.Id);
                    if (item.ActitivityType_Id == "NBC") { thisSVAc.Target = Convert.ToInt32( NBCTarget); }
                    if (item.ActitivityType_Id == "INCU") { thisSVAc.Target = Convert.ToInt32( INCUTarge); }
                    svActivityYearService.SetModified(thisSVAc);
                    svActivityYearService.SaveChanges();

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

        // GET: Admin/SVActivityYears/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SVActivityYear sVActivityYear = svActivityYearService.Find(id);
            if (sVActivityYear == null)
            {
                return HttpNotFound();
            }
            return View(sVActivityYear);
        }

        // POST: Admin/SVActivityYears/Delete/5
        [HttpPost]
       
        public ActionResult DeleteConfirmed(int id, string Year)
        {
            try
            {
                 var sv = svActivityYearService.getSVActivityYearBySVid(id,Convert.ToInt32(Year));
                 foreach (var item in sv) {
                 SVActivityYear sVActivityYear = svActivityYearService.Find(item.Id);
                 svActivityYearService.Remove(sVActivityYear);
                 svActivityYearService.SaveChanges();
                    
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
        public ActionResult DDLSVs()
        {
            var svs = SVService.All().ToList();
            if (svs == null)
            {
                return HttpNotFound();
            }
            return Json(svs, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DDLActivityType()
        {
            var activityType = ActivityTypeService.All().ToList();
            if (activityType == null)
            {
                return HttpNotFound();
            }
            return Json(activityType, JsonRequestBehavior.AllowGet);
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
