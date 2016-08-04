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

namespace NBC.Web.Areas.Admin.Controllers
{
    public class MasAmphursController : Controller
    {
        private MasAmphurService  service ;
        private MasProvinceService MasProvinceService;
        public MasAmphursController(MasAmphurService service, MasProvinceService masProvinceService)
        {
            this.service = service;
            this.MasProvinceService = masProvinceService;
        }


        // GET: Admin/MasAmphurs
        public ActionResult Index()
        {
            return View(service.GetAllAmphurd());
        }

        // GET: Admin/MasAmphurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasAmphur masAmphur = service.Find(id);
            if (masAmphur == null)
            {
                return HttpNotFound();
            }
            return View(masAmphur);
        }

        // GET: Admin/MasAmphurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MasAmphurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasAmphur masAmphur)
        {
            if (ModelState.IsValid)
            {
                service.Add(masAmphur);
                service.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masAmphur);
        }

        // GET: Admin/MasAmphurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasAmphur masAmphur = service.Find(id);
            if (masAmphur == null)
            {
                return HttpNotFound();
            }
            return View(masAmphur);
        }

        // POST: Admin/MasAmphurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MasAmphur masAmphur)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(masAmphur).State = EntityState.Modified;
                service.SetModified(masAmphur);
                service.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masAmphur);
        }

        // GET: Admin/MasAmphurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasAmphur masAmphur = service.Find(id);
            if (masAmphur == null)
            {
                return HttpNotFound();
            }
            return View(masAmphur);
        }

        // POST: Admin/MasAmphurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasAmphur masAmphur = service.Find(id);
            service.Remove(masAmphur);
            service.SaveChanges();
            return RedirectToAction("Index");
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
        public ActionResult DDLAmphur(int Id)
        {
            var amphur = service.GetAmphurByProvinceId(Id);
            if (amphur == null)
            {
                return HttpNotFound();
            }
            return Json(amphur, JsonRequestBehavior.AllowGet);
        }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
    }
}
