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
        Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CowsViewModel, Cattle>()));  
        
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
                    Text = "Ölü",
                    Value = "2"
                },
                new SelectListItem
                {
                    Text = "Satıldı",
                    Value = "3",
                }
            },"Value","Text");
 
        // GET: Cows
        public ActionResult Index()
        {
            return View(db.Repository.GetMany(m=>m.CattleTypeId==(int)CattleTypes.Cow));
        }
        public ActionResult Create()
        {
            var model = new CowsViewModel();
            model.StateSelectList = selectList;
            return View(model);
        }
        [HttpPost]
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
        public ActionResult Edit(int id, CowsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Cattle cow = mapper.Map<Cattle>(model);
                cow.Id = id;
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
        //[AjaxOnly]
        //public ActionResult ChangeState(int id)
        //{
        //    var repo = db.CowsRepository.GetById(id);

        //    db.CowsRepository.Update(repo);
        //    db.Commit();
        //    return JsonSuccess();
        //}
    }
}