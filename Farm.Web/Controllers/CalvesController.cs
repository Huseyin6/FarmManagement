using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web.Controllers
{
    public class CalvesController : Controller
    {
        // GET: Calves
        public ActionResult Index()
        {
            return View();
        }
    }
}