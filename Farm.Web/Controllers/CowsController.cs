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
    public class CowsController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MainContext());
        MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<CowsViewModel,Cow >());

        // GET: Cows
        public ActionResult Index()
        {
            return View(unitOfWork.CowsRepository.GetAll());
        }
        public ActionResult Create()
        {
            var model = new CowsViewModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CowsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mapper = new Mapper(config);
                Cow cow = mapper.Map<Cow>(model);
                unitOfWork.CowsRepository.Add(cow);
                unitOfWork.Complete();
            }
            return View(model);
        }
    }
}