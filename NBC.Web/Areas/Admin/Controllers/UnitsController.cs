using System.Net;
using System.Web.Mvc;
using NBC.Models;
using NBC.Services;
using System.Linq;

namespace NBC.Web.Areas.Admin.Controllers
{
    public class UnitsController : Controller
    {
        private UnitService unitService;
        private MasAmphurService MasAmphurService;
        private MasProvinceService MasProvinceService;
        private MasTambolService MasTambolService;
        public UnitsController(UnitService unitService, MasAmphurService masAmphurService, MasProvinceService masProvinceService, MasTambolService masTambolService)
        {
            this.unitService = unitService;
            this.MasAmphurService = masAmphurService;
            this.MasProvinceService = masProvinceService;
            this.MasTambolService = masTambolService;
        }


        // GET: Admin/Units
        public ActionResult Index()
        {
            return View(unitService.All());
        }

        // GET: Admin/Units/Details/5
        public ActionResult Details(int? id)
        {
            
            NBC.Models.Unit unit = unitService.Find(id);          
            return PartialView(unit);
        }

        // GET: Admin/Units/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]        
        public ActionResult Create(NBC.Models.Unit unit)
        {
            try
            {
                // TODO: Add insert logic here

                unitService.Add(unit);
                unitService.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Units/Edit/5
        public ActionResult Edit(int? id)
        {
          
            NBC.Models.Unit unit = unitService.Find(id);

            return PartialView(unit);
        }

        // POST: Admin/Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NBC.Models.Unit unit)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(unit).State = EntityState.Modified;               
                unitService.SetModified(unit);
                unitService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unit);
        }

        // GET: Admin/Units/Delete/5
        public ActionResult Delete(int? id)
        {
         
            NBC.Models.Unit unit = unitService.Find(id);         
            return View(unit);
        }

        // POST: Admin/Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(NBC.Models.Unit unit, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                unitService.Remove(unit);
                unitService.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DDLProvince()
        {
            var province = MasProvinceService.All().ToList();
            if (province == null)
            {
                return HttpNotFound();
            }
            return Json(province, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DDLAmphur(int Id)
        {
            var amphur = MasAmphurService.GetAmphurByProvinceId(Id);
            if (amphur == null)
            {
                return HttpNotFound();
            }
            return Json(amphur, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DDLTambol(int Id)
        {
            var tambol = MasTambolService.GetTambolByAmphurId(Id);
            if (tambol == null)
            {
                return HttpNotFound();
            }
            return Json(tambol, JsonRequestBehavior.AllowGet);
        }
    }
}
