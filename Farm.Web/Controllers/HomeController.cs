
using Farm.Data;
using Farm.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MainContext());

        public ActionResult Index()
        {
            return View();
        }
    }
}