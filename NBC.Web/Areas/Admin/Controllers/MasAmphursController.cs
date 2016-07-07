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

        public MasAmphursController(MasAmphurService service)
        {
            this.service = service;
        }


        // GET: Admin/MasAmphurs
        public ActionResult Index()
        {
            return View(service.All());
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
        public ActionResult Create([Bind(Include = "Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MasAmphur masAmphur)
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
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MasAmphur masAmphur)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(masAmphur).State = EntityState.Modified;
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
