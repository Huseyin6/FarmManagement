using AutoMapper;
using Farm.Data;
using Farm.Data.Entities;
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
        Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CalvesViewModel, Calf>()));

        public ActionResult Index()
        {
            return View(db.CalvesRepository.GetAll());
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
                Calf calf = mapper.Map<Calf>(model);
                db.CalvesRepository.Add(calf);
                db.Commit();
            }
            return View(model);
        }
    }
}