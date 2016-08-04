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
    public class MasSubBusinessTypesController : Controller
    {
        private MasSubBusinessTypeService service;

        private MasBusinessTypeService busService;

        public MasSubBusinessTypesController(MasSubBusinessTypeService service, MasBusinessTypeService busService)
        {
            this.service = service;
            this.busService = busService;
        }

        // GET: Admin/MasSubBusinessTypes
        public ActionResult Index()
        {
            return View(service.GetAllBusinessTypes());
        }

        // GET: Admin/MasSubBusinessTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasSubBusinessType masSubBusinessType = service.Find(id);
            if (masSubBusinessType == null)
            {
                return HttpNotFound();
            }
            return View(masSubBusinessType);
        }

        // GET: Admin/MasSubBusinessTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MasSubBusinessTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MasBusinessType_Id,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MasSubBusinessType masSubBusinessType)
        {
            if (ModelState.IsValid)
            {
                service.Add(masSubBusinessType);
                service.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masSubBusinessType);
        }

        // GET: Admin/MasSubBusinessTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasSubBusinessType masSubBusinessType = service.Find(id);
            if (masSubBusinessType == null)
            {
                return HttpNotFound();
            }
            return View(masSubBusinessType);
        }

        // POST: Admin/MasSubBusinessTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MasBusinessType_Id,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MasSubBusinessType masSubBusinessType)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(masSubBusinessType).State = EntityState.Modified;
                service.SetModified(masSubBusinessType);
                service.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masSubBusinessType);
        }

        // GET: Admin/MasSubBusinessTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasSubBusinessType masSubBusinessType = service.Find(id);
            if (masSubBusinessType == null)
            {
                return HttpNotFound();
            }
            return View(masSubBusinessType);
        }

        // POST: Admin/MasSubBusinessTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasSubBusinessType masSubBusinessType = service.Find(id);
            service.Remove(masSubBusinessType);
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

        public ActionResult DDLBusiness()
        {
            var business = busService.All().ToList();
            if (business == null)
            {
                return HttpNotFound();
            }
            return Json(business, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DDLSubBusiness(int Id)
        {
            var amphur = service.Find(Id);
            if (amphur == null)
            {
                return HttpNotFound();
            }
            return Json(amphur, JsonRequestBehavior.AllowGet);
        }
    }
}
