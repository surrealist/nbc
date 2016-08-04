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
    public class MasBusinessTypesController : Controller
    {
        private MasBusinessTypeService service;


        public MasBusinessTypesController(MasBusinessTypeService service)
        {
            this.service = service; 
        }

        // GET: Admin/MasBusinessTypes
        public ActionResult Index()
        {
            return View(service.All());
        }

        // GET: Admin/MasBusinessTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasBusinessType masBusinessType = service.Find(id);
            if (masBusinessType == null)
            {
                return HttpNotFound();
            }
            return View(masBusinessType);
        }

        // GET: Admin/MasBusinessTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MasBusinessTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MasBusinessType masBusinessType)
        {
            if (ModelState.IsValid)
            {
                service.Add(masBusinessType);
                service.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masBusinessType);
        }

        // GET: Admin/MasBusinessTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasBusinessType masBusinessType = service.Find(id);
            if (masBusinessType == null)
            {
                return HttpNotFound();
            }
            return View(masBusinessType);
        }

        // POST: Admin/MasBusinessTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MasBusinessType masBusinessType)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(masBusinessType).State = EntityState.Modified;
                service.SetModified(masBusinessType);
                service.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masBusinessType);
        }

        // GET: Admin/MasBusinessTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasBusinessType masBusinessType = service.Find(id);
            if (masBusinessType == null)
            {
                return HttpNotFound();
            }
            return View(masBusinessType);
        }

        // POST: Admin/MasBusinessTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasBusinessType masBusinessType = service.Find(id);
            service.Remove(masBusinessType);
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
