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
        private MasProvinceService proService;
        private MasAmphurService amService;

        public MasTambolsController(MasTambolService service,MasProvinceService proService,MasAmphurService amService)
        {
            this.service = service;
            this.proService = proService;
            this.amService = amService;
        }

        // GET: Admin/MasTambols
        public ActionResult Index()
        {
            return View(service.GetAllTambol());
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
        public ActionResult Create(MasTambol masTambol)
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
        public ActionResult Edit(MasTambol masTambol)
        {
            try
            {
                MasTambol thisTambol = service.Find(masTambol.Id);
                thisTambol.Name = masTambol.Name;
                service.SetModified(thisTambol);
                service.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
               return View(masTambol);
                
            }
                //db.Entry(masTambol).State = EntityState.Modified;
               
            
            
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
        [HttpGet]
        public ActionResult DDLProvince()
        {
            var province = proService.All().ToList();
            if (province == null)
            {
                return HttpNotFound();
            }
            return Json(province, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DDLAmphur(int Id)
        {
            var amphur = amService.GetAmphurByProvinceId(Id);
            if (amphur == null)
            {
                return HttpNotFound();
            }
            return Json(amphur, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DDLTambol(int Id)
        {
            var tambol = service.GetTambolByAmphurId(Id);
            if (tambol == null)
            {
                return HttpNotFound();
            }
            return Json(tambol, JsonRequestBehavior.AllowGet);
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
