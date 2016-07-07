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
    public class SVActivityYearsController : Controller
    {
        private SVActivityYearService svActivityYearService;


        public SVActivityYearsController(SVActivityYearService service)
        {
            this.svActivityYearService = service;
        }

        // GET: Admin/SVActivityYears
        public ActionResult Index()
        {
            return View(svActivityYearService.All());
        }

        // GET: Admin/SVActivityYears/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SVActivityYear sVActivityYear = svActivityYearService.Find(id);
            if (sVActivityYear == null)
            {
                return HttpNotFound();
            }
            return View(sVActivityYear);
        }

        // GET: Admin/SVActivityYears/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SVActivityYears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Target,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] SVActivityYear sVActivityYear)
        {
            if (ModelState.IsValid)
            {
                svActivityYearService.Add(sVActivityYear);
                svActivityYearService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sVActivityYear);
        }

        // GET: Admin/SVActivityYears/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SVActivityYear sVActivityYear = svActivityYearService.Find(id);
            if (sVActivityYear == null)
            {
                return HttpNotFound();
            }
            return View(sVActivityYear);
        }

        // POST: Admin/SVActivityYears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Target,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] SVActivityYear sVActivityYear)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(sVActivityYear).State = EntityState.Modified;
                svActivityYearService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sVActivityYear);
        }

        // GET: Admin/SVActivityYears/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SVActivityYear sVActivityYear = svActivityYearService.Find(id);
            if (sVActivityYear == null)
            {
                return HttpNotFound();
            }
            return View(sVActivityYear);
        }

        // POST: Admin/SVActivityYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SVActivityYear sVActivityYear = svActivityYearService.Find(id);
            svActivityYearService.Remove(sVActivityYear);
            svActivityYearService.SaveChanges();
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
