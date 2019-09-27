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
        public IEnumerable<SummaryFinancial> summaryFinancials { get; set; }
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

        public ActionResult Table()
        {
            ViewBag.Total = db.FinancialRepo.GetTotalForIncomeOrExpense();
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
                return RedirectToAction("Table", "Income");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {

            var model = db.FinancialRepo.GetById(id);
            var Vmodel = mapper.Map<BaseFinancialViewModel>(model);
            Vmodel.SelectList = selectList;
            return View(Vmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BaseFinancialViewModel model)
        {
            model.SelectList = selectList;
            if (ModelState.IsValid)
            {
                FinancialAsset asset = mapper.Map<FinancialAsset>(model);
                asset.Id = id;
                db.FinancialRepo.Update(asset);
                db.Commit();
                return RedirectToAction("Table", "Income");
            }
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            db.FinancialRepo.RemoveById(id);
            db.Commit();
            return RedirectToAction("Table", "Income");
        }
        [AjaxOnly]
        public JsonResult GetData()
        {
            var deneme = new List<SummaryFinancial>();
            for (int i = 1; i <= 12; i++)
            {
                if (db.FinancialRepo.GetTotalForFinancialType(i).Count() == 0)
                {
                    deneme.Add(Hesapla(i, "Süt Satışı"));
                    deneme.Add(Hesapla(i, "Hayvan Satışı"));
                    deneme.Add(Hesapla(i, "Teşvik"));
                    deneme.Add(Hesapla(i, "Diğer Gelirler"));
                }
                else if (db.FinancialRepo.GetTotalForFinancialType(i).Count() > 0)
                {
                    if (db.FinancialRepo.GetTotalForFinancialType(i).Where(m => m.Name == "Teşvik").Count() == 0)
                    {
                        deneme.Add(Hesapla(i, "Teşvik"));
                    }
                    if (db.FinancialRepo.GetTotalForFinancialType(i).Where(m => m.Name == "Süt Satışı").Count() == 0)
                    {
                        deneme.Add(Hesapla(i, "Süt Satışı"));
                    }
                    if (db.FinancialRepo.GetTotalForFinancialType(i).Where(m => m.Name == "Hayvan Satışı").Count() == 0)
                    {
                        deneme.Add(Hesapla(i, "Hayvan Satışı"));
                    }
                    if (db.FinancialRepo.GetTotalForFinancialType(i).Where(m => m.Name == "Diğer Gelirler").Count() == 0)
                    {
                        deneme.Add(Hesapla(i, "Diğer Gelirler"));
                    }
                }
                summaryFinancials = db.FinancialRepo.GetTotalForFinancialType(i);

                foreach (var item in summaryFinancials)
                {
                    item.Month = i;
                    deneme.Add(item);
                }

            }
            return Json(deneme.OrderBy(m => m.Month), JsonRequestBehavior.AllowGet);
        }
        public SummaryFinancial Hesapla(int i, string name)
        {
            var dene = new SummaryFinancial();
            dene.Name = name;
            dene.Sum = 0;
            dene.Month = i;
            return dene;
        }
    }
}