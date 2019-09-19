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
    public class SteersController : Controller
    {
        UnitOfWork db = new UnitOfWork(new MainContext());
        Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<SteersViewModel, Cattle>().ReverseMap()));

        SelectList selectList = new SelectList(new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Çiftlikte",
                    Value = "1",
                    Selected=true
                },
                new SelectListItem
                {
                    Text = "Satıldı",
                    Value = "2"
                },
                new SelectListItem
                {
                    Text = "Ölü",
                    Value = "3",
                }
            }, "Value", "Text");

        // GET: Steers
        public ActionResult Index(int? state)
        {
            if (state.HasValue)
            {
                return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Steer && m.StateId == state));
            }
            
            return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Steer));
        }
        public ActionResult Create()
        {
            var model = new SteersViewModel();
            model.StateSelectList = selectList;
            model.BirthDate = DateTime.Today;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(SteersViewModel model)
        {
            model.StateSelectList = selectList;
            if (ModelState.IsValid)
            {
                Cattle steer = mapper.Map<Cattle>(model);
                steer.CattleTypeId = (int)CattleTypes.Steer;
                steer.Sex = (int)Sex.Male;
                db.Repository.Add(steer);
                db.Commit();
                return RedirectToAction("Index", "Steers");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var model = db.Repository.GetById(id);
            var Vmodel = mapper.Map<SteersViewModel>(model);
            Vmodel.StateSelectList = selectList;
            return View(Vmodel);
        }
        [HttpPost]
        public ActionResult Edit(int id, SteersViewModel model)
        {
            model.StateSelectList = selectList;
            if (ModelState.IsValid)
            {
                Cattle steer = mapper.Map<Cattle>(model);
                steer.Id = id;
                steer.CattleTypeId = (int)CattleTypes.Steer;
                db.Repository.Update(steer);
                db.Commit();
                return RedirectToAction("Index", "Steers");
            }
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            db.Repository.RemoveById(id);
            db.Commit();
            return RedirectToAction("Index", "Steers");
        }

    }
}