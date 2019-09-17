using AutoMapper;
using Farm.Data;
using Farm.Data.Entities;
using Farm.Data.Enumerations;
using Farm.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web.Controllers
{
    public class CalvesController : Controller
    {
        UnitOfWork db = new UnitOfWork(new MainContext());
        Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CalvesViewModel, Cattle>()));

        public ActionResult Index()
        {
            return View(db.Repository.GetMany(m=>m.CattleTypeId==(int)CattleTypes.Calf));
        }
        public ActionResult Create(){
            var model = new CalvesViewModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CalvesViewModel model)
        {
            if (ModelState.IsValid)
            {
                Cattle calf = mapper.Map<Cattle>(model);
                db.Repository.Add(calf);
                db.Commit();
            }
            return View(model);
        }
    }
}