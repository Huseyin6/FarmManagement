using AutoMapper;
using Farm.Data;
using Farm.Data.Entities;
using Farm.Data.Enumerations;
using Farm.Data.Interfaces;
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
        UnitOfWork db = new UnitOfWork(new MainContext());
        Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CowsViewModel, Cattle>().ReverseMap()));  
        
        SelectList selectList= new SelectList(new List<SelectListItem>
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
            },"Value","Text");
 
        // GET: Cows
        public ActionResult Index(int? state, bool? IsPregnant, bool? IsLactation)
        {
            if(state.HasValue ){
                if(IsPregnant == null && IsLactation == null){
                    return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Cow && m.StateId == state));
                }
                else if(IsPregnant.HasValue){
                    return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Cow && m.StateId == state && m.IsPregnant));
                }
                else if (IsLactation.HasValue)
                {
                    return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Cow && m.StateId == state && m.IsLactation));
                }

            }
            else if(state == null && IsPregnant==true && IsLactation == null){
                return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Cow && m.IsPregnant && m.StateId == 1));
            }
            else if (state == null && IsPregnant == null && IsLactation == true)
            {
                return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Cow && m.IsLactation && m.StateId == 1));
            }
            return View(db.Repository.GetMany(m => m.CattleTypeId == (int)CattleTypes.Cow && m.StateId==1));
        }
        public ActionResult Create()
        {
            var model = new CowsViewModel();
            model.StateSelectList = selectList;
            model.BirthDate = DateTime.Today;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CowsViewModel model)
        {
            model.StateSelectList = selectList;
            if (ModelState.IsValid)
            {
                Cattle cow = mapper.Map<Cattle>(model);
                cow.CattleTypeId = (int)CattleTypes.Cow;
                cow.Sex = (int)Sex.Female;
                db.Repository.Add(cow);
                db.Commit();
                return RedirectToAction("Index", "Cows");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {

            var model = db.Repository.GetById(id);
            var Vmodel = mapper.Map<CowsViewModel>(model);
            Vmodel.StateSelectList = selectList;
            return View(Vmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CowsViewModel model)
        {
            model.StateSelectList = selectList;
            if (ModelState.IsValid)
            {
                Cattle cow = mapper.Map<Cattle>(model);
                cow.Id = id;
                cow.CattleTypeId = (int)CattleTypes.Cow;
                db.Repository.Update(cow);
                db.Commit();
                return RedirectToAction("Index", "Cows");
            }
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            db.Repository.RemoveById(id);
            db.Commit();
            return RedirectToAction("Index", "Cows");
        }
        [AjaxOnly]
        public ActionResult ChangePregnantState(int id)
        {
            var repo = db.Repository.GetById(id);
            if (repo.IsPregnant)
            {

                repo.IsPregnant = !repo.IsPregnant;
            }
            else
            {
                if(repo.PregnantDate.HasValue){
                    repo.IsPregnant = !repo.IsPregnant;
                }
                else{
                    return Json(new { success= false},JsonRequestBehavior.AllowGet);
                }
            }

            db.Repository.Update(repo);
            db.Commit();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        [AjaxOnly]
        public ActionResult ChangeLactationState(int id)
        {
            var repo = db.Repository.GetById(id);
            repo.IsLactation = !repo.IsLactation;
            db.Repository.Update(repo);
            db.Commit();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}