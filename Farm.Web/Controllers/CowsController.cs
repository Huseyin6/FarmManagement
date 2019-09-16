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
        UnitOfWork db = new UnitOfWork(new MainContext());
        Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<CowsViewModel, Cow>().ReverseMap()));

        // GET: Cows
        public ActionResult Index()
        {
            List<Cow> vmodel = new List<Cow>();

            return View(db.CowsRepository.GetAll());
        }
        public ActionResult Create()
        {
            var model = new CowsViewModel();
             var selectlistItem= new List<SelectListItem>
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
            };
            model.StateSelectList = new SelectList(selectlistItem, "Value", "Text");

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CowsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Cow cow = mapper.Map<Cow>(model);
                db.CowsRepository.Add(cow);
                db.Commit();
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            
            var model = db.CowsRepository.GetById(id);
            var Vmodel = mapper.Map<CowsViewModel>(model);
            var selectlistItem = new List<SelectListItem>
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
            };
            Vmodel.StateSelectList = new SelectList(selectlistItem, "Value", "Text");
            return View(Vmodel);
        }
        [HttpPost]
        public ActionResult Edit(int id,CowsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Cow cow = mapper.Map<Cow>(model);
                cow.Id = id;
                db.CowsRepository.Update(cow);
                db.Commit();
                return RedirectToAction("Index", "Cows");
            }
            return View(model);
        }
        public ActionResult Delete(int id){
            db.CowsRepository.RemoveById(id);
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