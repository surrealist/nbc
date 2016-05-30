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

    public HomeController(IService<Year> yearService) {
      this.yearService = yearService;
    }

    public ActionResult Index() {
      var items = yearService.All();
      return View(items);
    }

    public ActionResult About() {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact() {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}