using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        public ActionResult Table()
        {
            return View();
        }
        public ActionResult Statistic(){
            return View();
        }
    }
}