﻿using AutoMapper;
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
        Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CalvesViewModel, Cattle>().ReverseMap()));
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
        SelectList sexSelectList = new SelectList(new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Dişi",
                    Value = "0",
                    Selected=true
                },
                new SelectListItem
                {
                    Text = "Erkek",
                    Value = "1"
                }                
            }, "Value", "Text");
        public ActionResult Index(int? state, int? sex,bool? drinkmilk)
        {
            if (state.HasValue)
            {
                if (sex == null && drinkmilk == null)
                {
                    return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Calf && m.StateId == state));
                }
                else if (sex.HasValue)
                {
                    return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Calf && m.StateId == state && m.Sex==sex));
                }
                else if (drinkmilk.HasValue)
                {
                    return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Calf && m.StateId == state && m.DrinkMilk==drinkmilk));
                }

            }
            else if (state == null && sex.HasValue && drinkmilk == null)
            {
                return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Calf && m.Sex==sex));
            }
            else if (state == null && sex == null && drinkmilk.HasValue)
            {
                return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Calf && m.DrinkMilk == drinkmilk));
            }
            return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Calf));
        }
        public ActionResult Create()
        {
            var model = new CalvesViewModel();
            model.StateSelectList = selectList;
            model.SexSelectList = sexSelectList;
            model.BirthDate = DateTime.Today;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CalvesViewModel model)
        {
            model.StateSelectList = selectList;
            model.SexSelectList = sexSelectList;
            if (ModelState.IsValid)
            {
                Cattle calf = mapper.Map<Cattle>(model);
                calf.CattleTypeId = (int)CattleTypes.Calf;
                db.Repository.Add(calf);
                db.Commit();
                return RedirectToAction("Index", "Calves");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var model = db.Repository.GetById(id);
            var Vmodel = mapper.Map<CalvesViewModel>(model);
            Vmodel.StateSelectList = selectList;
            Vmodel.SexSelectList = sexSelectList;
            return View(Vmodel);
        }
        [HttpPost]
        public ActionResult Edit(int id, CalvesViewModel model)
        {
            model.StateSelectList = selectList;
            model.SexSelectList = sexSelectList;
            if (ModelState.IsValid)
            {
                Cattle calf = mapper.Map<Cattle>(model);
                calf.Id = id;
                calf.CattleTypeId = (int)CattleTypes.Calf;
                db.Repository.Update(calf);
                db.Commit();
                return RedirectToAction("Index", "Calves");
            }
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            db.Repository.RemoveById(id);
            db.Commit();
            return RedirectToAction("Index", "Calves");
        }
    }
}