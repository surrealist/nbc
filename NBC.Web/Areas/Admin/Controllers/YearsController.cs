using System.Net;
using System.Web.Mvc;
using NBC.Models;
using NBC.Services;

namespace NBC.Web.Areas.Admin.Controllers
{
    public class YearsController : Controller
    {
        private YearService yearService;

        public YearsController(YearService yearService)
        {
            this.yearService = yearService;
        }

        // GET: Admin/Years
        public ActionResult Index()
        {
           // Session["SELECTED"] = "2556";
             return View(yearService.All());
           // return View();
        }

        // GET: Admin/Years/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Year year = yearService.Find(id);
            if (year == null)
            {
                return HttpNotFound();
            }
            return View(year);
        }

        // GET: Admin/Years/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Years/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StartDate,EndDate,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Year year)
        {
            if (ModelState.IsValid)
            {
                yearService.Add(year);
                yearService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(year);
        }

        // GET: Admin/Years/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Year year = yearService.Find(id);
            if (year == null)
            {
                return HttpNotFound();
            }
            return View(year);
        }

        // POST: Admin/Years/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StartDate,EndDate,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Year year)
        {
            if (ModelState.IsValid)
            {
               // yearService.Entry(year).State = EntityState.Modified;
                yearService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(year);
        }

        // GET: Admin/Years/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Year year = yearService.Find(id);
            if (year == null)
            {
                return HttpNotFound();
            }
            return View(year);
        }

        // POST: Admin/Years/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Year year = yearService.Find(id);
            yearService.Remove(year);
            yearService.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        yearService.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
