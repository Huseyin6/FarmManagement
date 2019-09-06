using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web.Controllers
{
    public class AnimalManagementController : Controller
    {
        // GET: AnimalManagement
        public ActionResult Cows()
        {
            return View();
        }
        public ActionResult Calves(){
            return View();
        }
        public ActionResult Heifers()
        {
            return View();
        }
        public ActionResult Steers()
        {
            return View();
        }
    }
}