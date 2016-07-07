using System.Net;
using System.Web.Mvc;
using NBC.Models;
using NBC.Services;

namespace NBC.Web.Areas.Admin.Controllers
{
    public class UnitsController : Controller
    {
        private UnitService unitService;
        public UnitsController(UnitService unitService)
        {
            this.unitService = unitService;
        }


        // GET: Admin/Units
        public ActionResult Index()
        {
            return View(unitService.All());
        }

        // GET: Admin/Units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBC.Models.Unit unit = unitService.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: Admin/Units/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Alias,Address,Tel,Email,ContactPersonName,ConactPersonTel,ContactPersonEmail,HeadPersonName,HeadPersonTel,HeadPersonEmail,Notes,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] NBC.Models.Unit unit)
        {
            if (ModelState.IsValid)
            {
                unitService.Add(unit);
                unitService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unit);
        }

        // GET: Admin/Units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBC.Models.Unit unit = unitService.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Admin/Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Alias,Address,Tel,Email,ContactPersonName,ConactPersonTel,ContactPersonEmail,HeadPersonName,HeadPersonTel,HeadPersonEmail,Notes,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] NBC.Models.Unit unit)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(unit).State = EntityState.Modified;               

                unitService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unit);
        }

        // GET: Admin/Units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NBC.Models.Unit unit = unitService.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Admin/Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NBC.Models.Unit unit = unitService.Find(id);
            unitService.Remove(unit);
            unitService.SaveChanges();
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
