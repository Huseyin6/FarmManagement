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
    public class HeifersController : Controller
    {
        UnitOfWork db = new UnitOfWork(new MainContext());
        Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<HeifersViewModel, Cattle>().ReverseMap()));

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

        // GET: Heifers
        public ActionResult Index(int? state, bool? IsPregnant)
        {
            if(state.HasValue){
                if(IsPregnant.HasValue && IsPregnant==true){
                    return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Heifer && m.StateId == state && m.IsPregnant));
                }
                else{
                    return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Heifer && m.StateId == state));
                }
            }
            else if(state==null && IsPregnant.HasValue){
                return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Heifer && m.IsPregnant));
            }
            return View(db.Repository.GetMany(m=>m.CattleTypeId==(int)CattleTypes.Heifer));
        }
        public ActionResult Create()
        {
            var model = new HeifersViewModel();
            model.StateSelectList = selectList;
            model.BirthDate = DateTime.Today;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(HeifersViewModel model)
        {
            model.StateSelectList = selectList;
            if (ModelState.IsValid)
            {
                Cattle heifer = mapper.Map<Cattle>(model);
                heifer.CattleTypeId = (int)CattleTypes.Heifer;
                heifer.Sex = (int)Sex.Female;
                db.Repository.Add(heifer);
                db.Commit();
                return RedirectToAction("Index", "Heifers");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var model = db.Repository.GetById(id);
            var Vmodel = mapper.Map<HeifersViewModel>(model);
            Vmodel.StateSelectList = selectList;
            return View(Vmodel);
        }
        [HttpPost]
        public ActionResult Edit(int id, HeifersViewModel model)
        {
            model.StateSelectList = selectList;
            if (ModelState.IsValid)
            {
                Cattle heifer = mapper.Map<Cattle>(model);
                heifer.Id = id;
                heifer.CattleTypeId = (int)CattleTypes.Heifer;
                db.Repository.Update(heifer);
                db.Commit();
                return RedirectToAction("Index", "Heifers");
            }
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            db.Repository.RemoveById(id);
            db.Commit();
            return RedirectToAction("Index", "Cows");
        }

    }
}