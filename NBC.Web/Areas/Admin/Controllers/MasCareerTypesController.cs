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
    public class MasCareerTypesController : Controller
    {
        private MasCareerTypeService service;

        public MasCareerTypesController(MasCareerTypeService service)
        {
            this.service = service;
        }

        // GET: Admin/MasCareerTypes
        public ActionResult Index()
        {
            return View(service.All());
        }

        // GET: Admin/MasCareerTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasCareerType masCareerType = service.Find(id);
            if (masCareerType == null)
            {
                return HttpNotFound();
            }
            return View(masCareerType);
        }

        // GET: Admin/MasCareerTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MasCareerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MasCareerType masCareerType)
        {
            if (ModelState.IsValid)
            {
                service.Add(masCareerType);
                service.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masCareerType);
        }

        // GET: Admin/MasCareerTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasCareerType masCareerType = service.Find(id);
            if (masCareerType == null)
            {
                return HttpNotFound();
            }
            return View(masCareerType);
        }

        // POST: Admin/MasCareerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MasCareerType masCareerType)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(masCareerType).State = EntityState.Modified;
                service.SetModified(masCareerType);
                service.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masCareerType);
        }

        // GET: Admin/MasCareerTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasCareerType masCareerType = service.Find(id);
            if (masCareerType == null)
            {
                return HttpNotFound();
            }
            return View(masCareerType);
        }

        // POST: Admin/MasCareerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasCareerType masCareerType = service.Find(id);
            service.Remove(masCareerType);
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
