using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NBC.Services;
using NBC.Web.Models;
using NBC.Models;


namespace NBC.Web.Areas.Admin.Controllers
{
    public class SVsController : Controller
    {
        // GET: Admin/SVs
        private SVService SVService;
        private MasAmphurService MasAmphurService;
        private MasProvinceService MasProvinceService;
        private MasTambolService MasTambolService;
        public SVsController(SVService svService, MasAmphurService masAmphurService, MasProvinceService masProvinceService, MasTambolService masTambolService)
        {
            this.SVService = svService;
            this.MasAmphurService = masAmphurService;
            this.MasProvinceService = masProvinceService;
            this.MasTambolService = masTambolService;
        }
        public ActionResult Index()
        {

            
            return View(SVService.All());
        }

        // GET: Admin/SVs/Details/5
        public ActionResult Details(int id)
        {
            NBC.Models.SV sv = SVService.Find(id);
            return PartialView(sv);
        }

        // GET: Admin/SVs/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/SVs/Create
        [HttpPost]
        public ActionResult Create(NBC.Models.SV sv)
        {
            try
            {
                // TODO: Add insert logic here
                
                SVService.Add(sv);
                SVService.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SVs/Edit/5
        public ActionResult Edit(int id)
        {
            NBC.Models.SV sv = SVService.Find(id);
            return PartialView(sv);
        }

        // POST: Admin/SVs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NBC.Models.SV sv)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(unit).State = EntityState.Modified;               
                SVService.SetModified(sv);
                SVService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sv);
        }

        // GET: Admin/SVs/Delete/5
        public ActionResult Delete(int id)
        {
            NBC.Models.SV sv = SVService.Find(id);
            return View(sv);
        }

        // POST: Admin/SVs/Delete/5
        [HttpPost]
        public ActionResult Delete(NBC.Models.SV sv)
        {
            try
            {
                // TODO: Add delete logic here
                sv = SVService.Find(sv.Id);
                SVService.Remove(sv);
                SVService.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult DDLProvince()
        {
            var province = MasProvinceService.All().ToList();
            if (province == null)
            {
                return HttpNotFound();
            }
            return Json(province, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DDLAmphur(int Id)
        {
            var amphur = MasAmphurService.GetAmphurByProvinceId(Id);
            if (amphur == null)
            {
                return HttpNotFound();
            }
            return Json(amphur, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DDLTambol(int Id)
        {
            var tambol = MasTambolService.GetTambolByAmphurId(Id);
            if (tambol == null)
            {
                return HttpNotFound();
            }
            return Json(tambol, JsonRequestBehavior.AllowGet);
        }
    }
}
