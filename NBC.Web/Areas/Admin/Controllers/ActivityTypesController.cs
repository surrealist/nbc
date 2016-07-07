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
    public class ActivityTypesController : Controller
    {
        private ActivityTypeService  service;


        public ActivityTypesController(ActivityTypeService service)
        {
            this.service = service;
        }

        // GET: Admin/ActivityTypes
        public ActionResult Index()
        {
            return View(service.All());
        }

        // GET: Admin/ActivityTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityType activityType = service.Find(id);
            if (activityType == null)
            {
                return HttpNotFound();
            }
            return View(activityType);
        }

        // GET: Admin/ActivityTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ActivityTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] ActivityType activityType)
        {
            if (ModelState.IsValid)
            {
                service.Add(activityType);
                service.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activityType);
        }

        // GET: Admin/ActivityTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityType activityType = service.Find(id);
            if (activityType == null)
            {
                return HttpNotFound();
            }
            return View(activityType);
        }

        // POST: Admin/ActivityTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] ActivityType activityType)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(activityType).State = EntityState.Modified;
                service.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activityType);
        }

        // GET: Admin/ActivityTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityType activityType = service.Find(id);
            if (activityType == null)
            {
                return HttpNotFound();
            }
            return View(activityType);
        }

        // POST: Admin/ActivityTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityType activityType = service.Find(id);
            service.Remove(activityType);
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
