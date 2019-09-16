using Farm.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web.Controllers
{
    public class SteersController : Controller
    {
        UnitOfWork db = new UnitOfWork(new MainContext());

        // GET: Steers
        public ActionResult Index()
        {
            return View(db.SteerRepository.GetAll());
        }
    }
}