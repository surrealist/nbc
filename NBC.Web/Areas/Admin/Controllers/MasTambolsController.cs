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
    public class MasTambolsController : Controller
    {
        private MasTambolService service;

        public MasTambolsController(MasTambolService service)
        {
            this.service = service;
        }

        // GET: Admin/MasTambols
        public ActionResult Index()
        {
            return View(service.All());
        }

        // GET: Admin/MasTambols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasTambol masTambol = service.Find(id);
            if (masTambol == null)
            {
                return HttpNotFound();
            }
            return View(masTambol);
        }

        // GET: Admin/MasTambols/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MasTambols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Latitude,Longtitude,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MasTambol masTambol)
        {
            if (ModelState.IsValid)
            {
                service.Add(masTambol);
                service.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masTambol);
        }

        // GET: Admin/MasTambols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasTambol masTambol = service.Find(id);
            if (masTambol == null)
            {
                return HttpNotFound();
            }
            return View(masTambol);
        }

        // POST: Admin/MasTambols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Latitude,Longtitude,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MasTambol masTambol)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(masTambol).State = EntityState.Modified;
                service.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masTambol);
        }

        // GET: Admin/MasTambols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasTambol masTambol = service.Find(id);
            if (masTambol == null)
            {
                return HttpNotFound();
            }
            return View(masTambol);
        }

        // POST: Admin/MasTambols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasTambol masTambol = service.Find(id);
            service.Remove(masTambol);
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
