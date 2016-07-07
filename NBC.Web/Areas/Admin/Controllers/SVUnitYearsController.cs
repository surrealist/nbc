using System.Net;
using System.Web.Mvc;
using NBC.Models;
using NBC.Services;

namespace NBC.Web.Areas.Admin.Controllers
{
    public class SVUnitYearsController : Controller
    {
        private SVUnitYearService svunitYearService;
        public SVUnitYearsController(SVUnitYearService svunitYearService)
        {
            this.svunitYearService = svunitYearService;
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
        public ActionResult Create([Bind(Include = "Id,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] SVUnitYear svunitYear)
        {
            if (ModelState.IsValid)
            {
                svunitYearService.Add(svunitYear);
                svunitYearService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(svunitYear);
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
        public ActionResult Edit([Bind(Include = "Id,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] SVUnitYear svunitYear)
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
        public ActionResult DeleteConfirmed(int id)
        {
            SVUnitYear svunitYear = svunitYearService.Find(id);
            svunitYearService.Remove(svunitYear);
            svunitYearService.SaveChanges();
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
