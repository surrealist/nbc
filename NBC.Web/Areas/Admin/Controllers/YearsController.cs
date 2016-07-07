using System.Net;
using System.Web.Mvc;
using NBC.Models;
using NBC.Services;
using System;

namespace NBC.Web.Areas.Admin.Controllers
{
    public class YearsController : Controller
    {
        private YearService yearService;
        private SettingService settingService;

        public YearsController(YearService yearService, SettingService settingService)
        {
            this.yearService = yearService;
            this.settingService = settingService;            
        }

        // GET: Admin/Years
        public ActionResult Index()
        {
            // Session["SELECTED"] = "2556";
            var items = yearService.All();
            var currentYear = settingService.Current.CurrentYearId;
            ViewBag.Y = currentYear;
            return View(items);          
           // return View();
        }
        public ActionResult SetCurrentYear(string year)
        {
            try
            {
               
              settingService.ChangeCurrentYear(Convert.ToInt32(year));
                Year thisyear = yearService.Find(Convert.ToInt32(year));
                thisyear.IsLock = false;
                yearService.SaveChanges();
                return this.Json(new { success = true });
            }
            catch (System.Exception)
            {

                return this.Json(new { success = false });
            }
           

            
        }
        public ActionResult SetIsLockYear(string year)
        {
            try
            {
                var currentYear = settingService.Current.CurrentYearId;
                if (currentYear != Convert.ToInt32(year))
                {
                    Year thisyear = yearService.Find(Convert.ToInt32(year));
                    if (thisyear.IsLock != true)
                    {
                        thisyear.IsLock = true;
                    }
                    else {
                        thisyear.IsLock = false;
                    }
                   
                    yearService.SaveChanges();
                    return this.Json(new { success = true });
                }
                else {
                    Year thisyear = yearService.Find(Convert.ToInt32(year));
                    thisyear.IsLock = false;
                    yearService.SaveChanges();
                    return this.Json(new { success = false});
                }
               // settingService.ChangeCurrentYear(Convert.ToInt32(year));
               
            }
            catch (System.Exception)
            {

                return this.Json(new { success = false });
            }



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
            return PartialView(year);
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
            return PartialView(year);
        }

        // POST: Admin/Years/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Year year)
        {
            if (ModelState.IsValid)
            {
                yearService.SetModified(year);
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
            return PartialView(year);
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
