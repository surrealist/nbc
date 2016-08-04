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
    public class MasEducationTypesController : Controller
    {
        private MasEducationTypeService service;

        public MasEducationTypesController(MasEducationTypeService service)
        {
            this.service = service;
        }

        // GET: Admin/MasEducationTypes
        public ActionResult Index()
        {
            return View(service.All());
        }

        // GET: Admin/MasEducationTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasEducationType masEducationType = service.Find(id);
            if (masEducationType == null)
            {
                return HttpNotFound();
            }
            return View(masEducationType);
        }

        // GET: Admin/MasEducationTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MasEducationTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MasEducationType masEducationType)
        {
            if (ModelState.IsValid)
            {
                service.Add(masEducationType);
                service.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masEducationType);
        }

        // GET: Admin/MasEducationTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasEducationType masEducationType = service.Find(id);
            if (masEducationType == null)
            {
                return HttpNotFound();
            }
            return View(masEducationType);
        }

        // POST: Admin/MasEducationTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MasEducationType masEducationType)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(masEducationType).State = EntityState.Modified;
                service.SetModified(masEducationType);
                service.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masEducationType);
        }

        // GET: Admin/MasEducationTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasEducationType masEducationType = service.Find(id);
            if (masEducationType == null)
            {
                return HttpNotFound();
            }
            return View(masEducationType);
        }

        // POST: Admin/MasEducationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasEducationType masEducationType = service.Find(id);
            service.Remove(masEducationType);
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
