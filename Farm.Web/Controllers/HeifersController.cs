using Farm.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web.Controllers
{
    public class HeifersController : Controller
    {
        UnitOfWork db = new UnitOfWork(new MainContext());

        // GET: Heifers
        public ActionResult Index()
        {
            return View(db.HeiferRepository.GetAll());
        }
    }
}