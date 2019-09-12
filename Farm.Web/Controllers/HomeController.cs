
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

        public ActionResult Index()
        {
                //using (var context=new MainContext()){
                //    var test = new Test()
                //    {
                //        Name = "tset"
                //    };
                //    context.Tests.Add(test);
                //    context.SaveChanges();

                //    var list = context.Tests;
                //}
            return View();
        }
    }
}