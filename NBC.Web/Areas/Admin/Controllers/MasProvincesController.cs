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
    public class MasProvincesController : Controller
    {
        private MasProvinceService service;

        public MasProvincesController(MasProvinceService service)
        {
            this.service = service;
        }

        // GET: Admin/MasProvinces
        public ActionResult Index()
        {
            return View(service.All());
        }

        // GET: Admin/MasProvinces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasProvince masProvince = service.Find(id);
            if (masProvince == null)
            {
                return HttpNotFound();
            }
            return View(masProvince);
        }

        // GET: Admin/MasProvinces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MasProvinces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MasProvince masProvince)
        {
            if (ModelState.IsValid)
            {
                service.Add(masProvince);
                service.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masProvince);
        }

        // GET: Admin/MasProvinces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasProvince masProvince = service.Find(id);
            if (masProvince == null)
            {
                return HttpNotFound();
            }
            return View(masProvince);
        }

        // POST: Admin/MasProvinces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MasProvince masProvince)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(masProvince).State = EntityState.Modified;
                service.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masProvince);
        }

        // GET: Admin/MasProvinces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasProvince masProvince = service.Find(id);
            if (masProvince == null)
            {
                return HttpNotFound();
            }
            return View(masProvince);
        }

        // POST: Admin/MasProvinces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasProvince masProvince = service.Find(id);
            service.Remove(masProvince);
            service.SaveChanges();
            return RedirectToAction("Index");
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
