using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBC.Web.Controllers
{    public class SetSessionController : Controller
    {
        public ActionResult SetVariable(string key, object value)
        {
            Session[key] = value;

            return this.Json(new { success = true });
        }
    }
}