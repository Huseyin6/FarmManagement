using Farm.Data;
using Farm.Data.Interfaces;
using Farm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web.Controllers
{
    public class HomeController : Controller
    {
        //private IUnitOfWork _db;
        //public HomeController(IUnitOfWork db)
        //{
        //    _db = db;
        //}
        // GET: Home
        public ActionResult Index()
        {
            //using(var context = new MainContext()){
            //    return Json(context.Cows.ToList(),JsonRequestBehavior.AllowGet);
            //}
            return View();
        }
    }
}