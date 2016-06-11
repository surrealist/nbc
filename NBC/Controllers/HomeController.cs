using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NBC.Models;
using NBC.Services;
using NBC.Services.Bases;

namespace NBC.Controllers {
  public class HomeController : Controller {

    private IService<Year> yearService;
    private SettingService settingService;

    public HomeController(IService<Year> yearService,
                          IService<Setting> settingService) {
      this.yearService = yearService;
      this.settingService = (SettingService)settingService;
    }

    public ActionResult Index() {
      var items = yearService.All();
      var currentYear = settingService.Current.CurrentYearId;
      ViewBag.Y = currentYear;
      return View(items);
    }

    public ActionResult About() {
      var currentYear = settingService.Current.CurrentYearId;
      ViewBag.Y = currentYear;
      return View();
    }

    public ActionResult Contact() {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    [HttpPost]
    public ActionResult ChangeCurrentYear(int year) {
      settingService.ChangeCurrentYear(year);
      settingService.SaveChanges();

      return RedirectToAction("Index");
    }
  }
}