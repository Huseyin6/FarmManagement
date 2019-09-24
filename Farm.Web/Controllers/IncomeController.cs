using AutoMapper;
using Farm.Data;
using Farm.Data.Entities;
using Farm.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web.Controllers
{
    public class IncomeController : Controller
    {
        UnitOfWork db = new UnitOfWork(new MainContext());
        Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<BaseFinancialViewModel, FinancialAsset>().ReverseMap()));

        SelectList selectList = new SelectList(new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Süt Satışı",
                    Value = "1",
                    Selected=true
                },
                new SelectListItem
                {
                    Text = "Hayvan Satışı",
                    Value = "2"
                },
                new SelectListItem
                {
                    Text = "Teşvik",
                    Value = "3",
                },
                new SelectListItem
                {
                    Text = "Diğer Gelirler",
                    Value = "4",
                }
            }, "Value", "Text");
        public IncomeController()
        {
        }
        // GET: Cows
        public ActionResult Table()
        {
            ViewBag.Total = db.FinancialRepo.GetTotalForFinancialType();
            return View(db.FinancialRepo.GetMany(m => m.FinancialAssetTypeId < 5));
        }
        public ActionResult Statistic()
        {
            return View();
        }
        public ActionResult Create(){
            var model = new BaseFinancialViewModel();
            model.SelectList = selectList;
            model.TransactionDate = DateTime.Today;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BaseFinancialViewModel model)
        {
            model.SelectList = selectList;
            if (ModelState.IsValid)
            {
                FinancialAsset asset = mapper.Map<FinancialAsset>(model);
                db.FinancialRepo.Add(asset);
                db.Commit();
                return RedirectToAction("Index", "Cows");
            }
            return View(model);
        }
    }
}