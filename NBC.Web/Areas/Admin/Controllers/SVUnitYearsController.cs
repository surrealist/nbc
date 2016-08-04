using System.Net;
using System.Web.Mvc;
using NBC.Models;
using NBC.Services;
using System.Linq;

namespace NBC.Web.Areas.Admin.Controllers
{
    public class SVUnitYearsController : Controller
    {
        private SVUnitYearService svunitYearService;
        private YearService YearService;
        private SVService SVService;
        private SettingService settingService;
        private UnitService UnitService;
        public SVUnitYearsController(SVUnitYearService svunitYearService, YearService yearService, SVService svService, SettingService settingService, UnitService unitService)
        {
            this.svunitYearService = svunitYearService;
            this.YearService = yearService;
            this.SVService = svService;           
            this.settingService = settingService;
            this.UnitService = unitService;
        }

        // GET: Admin/SVUnitYears
        public ActionResult Index()
        {
            return View(svunitYearService.All());
        }

        // GET: Admin/SVUnitYears/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SVUnitYear svunit = svunitYearService.Find(id);
            if (svunit == null)
            {
                return HttpNotFound();
            }
            return View(svunit);
        }

        // GET: Admin/SVUnitYears/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SVUnitYears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SVUnitYear svUnitYear)
        {
            try
            {
               SVUnitYear thisSVUnit = svUnitYear;
                NBC.Models.SV sv = SVService.Find(thisSVUnit.SV.Id);
                NBC.Models.Unit unit = UnitService.Find(thisSVUnit.Unit.Id);
                NBC.Models.Year year = YearService.Find(thisSVUnit.Year.Id);

                thisSVUnit.SV = sv;
                thisSVUnit.Year = year;
                thisSVUnit.Unit = unit;

                svunitYearService.Add(thisSVUnit);
                svunitYearService.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {

                return View(svUnitYear);
            }
           
               
            
           
        }

        // GET: Admin/SVUnitYears/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SVUnitYear svunitYear = svunitYearService.Find(id);
            if (svunitYear == null)
            {
                return HttpNotFound();
            }
            return View(svunitYear);
        }

        // POST: Admin/SVUnitYears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SVUnitYear svunitYear)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(unit).State = EntityState.Modified;               

                svunitYearService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(svunitYear);
        }

        // GET: Admin/SVUnitYears/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SVUnitYear svunitYear = svunitYearService.Find(id);
            if (svunitYear == null)
            {
                return HttpNotFound();
            }
            return View(svunitYear);
        }

        // POST: Admin/SVUnitYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(SVUnitYear svunitYear)
        {
            svunitYear = svunitYearService.Find(svunitYear.Id);
            svunitYearService.Remove(svunitYear);
            svunitYearService.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DDLYear()
        {
            var years = YearService.GetYear();
            if (years == null)
            {
                return HttpNotFound();
            }
            return Json(years, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DDLSVs()
        {
            var svs = SVService.All().ToList();
            if (svs == null)
            {
                return HttpNotFound();
            }
            return Json(svs, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DDLUnits()
        {

            var unit = UnitService.All().ToList();
            if (unit == null)
            {
                return HttpNotFound();
            }
            return Json(unit, JsonRequestBehavior.AllowGet);
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
