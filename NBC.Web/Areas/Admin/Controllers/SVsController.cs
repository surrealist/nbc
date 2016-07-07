using System.Net;
using System.Web.Mvc;
using NBC.Models;
using NBC.Services;
using System;

namespace NBC.Web.Areas.Admin.Controllers
{
    public class SVsController : Controller
    {
        private SVService svService;
        private SettingService settingService;

        public SVsController(SVService svService,SettingService settingService)
        {
            this.svService = svService;
            this.settingService = settingService;
        }

        // GET: Admin/SVs
        public ActionResult Index()
        {
            return View(svService.All());
        }

        // GET: Admin/SVs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           NBC.Models.SV sv = svService.Find(id);
            if (sv == null)
            {
                return HttpNotFound();
            }
            return View(sv);
        }

        // GET: Admin/SVs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SVs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Alias,Tel,Email,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] NBC.Models.SV sv)
        {
            if (ModelState.IsValid)
            {
                svService.Add(sv);
                svService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sv);
        }

        // GET: Admin/SVs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBC.Models.SV sv = svService.Find(id);
            if (sv == null)
            {
                return HttpNotFound();
            }
            return PartialView(sv);
        }

        // POST: Admin/SVs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Alias,Tel,Email,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] NBC.Models.SV sv)
        {
            if (ModelState.IsValid)
            {
                svService.SetModified(sv);
                svService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sv);
        }

        // GET: Admin/SVs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBC.Models.SV sv = svService.Find(id);
            if (sv == null)
            {
                return HttpNotFound();
            }
            return View(sv);
        }
        // POST: Admin/SVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NBC.Models.SV sv = svService.Find(id);
            svService.Remove(sv);
            svService.SaveChanges();
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
