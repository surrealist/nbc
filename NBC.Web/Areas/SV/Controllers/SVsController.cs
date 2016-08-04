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

namespace NBC.Web.Areas.SV.Controllers
{
    public class SVsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        private SVService SVService;
        private MasAmphurService MasAmphurService;
        private MasProvinceService MasProvinceService;
        private MasTambolService MasTambolService;
        private UserService userService;
        public SVsController(SVService svService, MasAmphurService masAmphurService, MasProvinceService masProvinceService, MasTambolService masTambolService, UserService userService)
        {
            this.SVService = svService;
            this.MasAmphurService = masAmphurService;
            this.MasProvinceService = masProvinceService;
            this.MasTambolService = masTambolService;
            this.userService = userService;
        }
        public ActionResult Index()
        {
            if (!userService.CurrentUserInRole("SV"))
            {
                return new HttpUnauthorizedResult();
            }
            var Roles = userService.GetRoles();
            var WA_ID = 0;
            foreach (var role in Roles)
            {
                if (role.Role.RoleName == "SV")
                {
                   WA_ID = role.WorkAt.Id;
                }
            }
            return View(SVService.Find(WA_ID));
        }

        // GET: SV/SVs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBC.Models.SV sV = SVService.Find(id);
            if (sV == null)
            {
                return HttpNotFound();
            }
            return View(sV);
        }

        // GET: SV/SVs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SV/SVs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Alias,Adress,Tel,Email,Notes,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] NBC.Models.SV sV)
        {
            if (ModelState.IsValid)
            {
                db.WorkPlace.Add(sV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sV);
        }

        // GET: SV/SVs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBC.Models.SV sV = SVService.Find(id);
            if (sV == null)
            {
                return HttpNotFound();
            }
            return View(sV);
        }

        // POST: SV/SVs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Alias,Adress,Tel,Email,Notes,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] NBC.Models.SV sV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sV);
        }

        // GET: SV/SVs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBC.Models.SV sV = SVService.Find(id);
            if (sV == null)
            {
                return HttpNotFound();
            }
            return View(sV);
        }

        // POST: SV/SVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NBC.Models.SV sV = SVService.Find(id);
            db.WorkPlace.Remove(sV);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
