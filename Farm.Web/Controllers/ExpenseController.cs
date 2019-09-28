using AutoMapper;
using Farm.Data;
using Farm.Data.Entities;
using Farm.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web.Controllers
{
    public class ExpenseController : Controller
    {
        UnitOfWork db = new UnitOfWork(new MainContext());
        Mapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<BaseFinancialViewModel, FinancialAsset>().ReverseMap()));
        public IEnumerable<SummaryFinancial> summaryFinancials { get; set; }
        SelectList selectList = new SelectList(new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Yem Alımı",
                    Value = "5",
                    Selected=true
                },
                new SelectListItem
                {
                    Text = "İlaç Alımı",
                    Value = "6"
                },
                new SelectListItem
                {
                    Text = "Veteriner Ücreti",
                    Value = "7",
                },
                new SelectListItem
                {
                    Text = "Çiftlik Giderleri",
                    Value = "8",
                },
                 new SelectListItem
                {
                    Text = "Diğer Giderler",
                    Value = "9",
                }
            }, "Value", "Text");

        public ExpenseController()
        {
        }
        public ActionResult Table()
        {
            ViewBag.Total = db.FinancialRepo.GetTotalForIncomeOrExpense(1);
            return View(db.FinancialRepo.GetMany(m => m.FinancialAssetTypeId >= 5));
        }
        public ActionResult Statistic()
        {
            return View();
        }
        public ActionResult Create()
        {
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
                return RedirectToAction("Table", "Expense");
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
                return RedirectToAction("Table", "Expense");
            }
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            db.FinancialRepo.RemoveById(id);
            db.Commit();
            return RedirectToAction("Table", "Expense");
        }

        [AjaxOnly]
        public JsonResult GetData()
        {
            var deneme = new List<SummaryFinancial>();
            for (int i = 1; i <= 12; i++)
            {
                if (db.FinancialRepo.GetTotalForFinancialType(i).Count()==0){
                    deneme.Add(Hesapla(i, "Yem Alımı"));
                    deneme.Add(Hesapla(i, "İlaç Alımı"));
                    deneme.Add(Hesapla(i, "Veteriner Ücreti"));
                    deneme.Add(Hesapla(i, "Çiftlik Giderleri"));
                    deneme.Add(Hesapla(i, "Diğer Giderler"));
                }    
                else if(db.FinancialRepo.GetTotalForFinancialType(i).Count()>0 ){
                    if(db.FinancialRepo.GetTotalForFinancialType(i).Where(m => m.Name == "Yem Alımı").Count() == 0){
                        deneme.Add(Hesapla(i, "Yem Alımı"));
                    }
                    if(db.FinancialRepo.GetTotalForFinancialType(i).Where(m => m.Name == "İlaç Alımı").Count() == 0){
                        deneme.Add(Hesapla(i, "İlaç Alımı"));
                    }
                    if (db.FinancialRepo.GetTotalForFinancialType(i).Where(m => m.Name == "Veteriner Ücreti").Count() == 0)
                    {
                        deneme.Add(Hesapla(i, "Veteriner Ücreti"));
                    }
                    if(db.FinancialRepo.GetTotalForFinancialType(i).Where(m => m.Name == "Çiftlik Giderleri").Count() == 0) 
                    {
                        deneme.Add(Hesapla(i, "Çiftlik Giderleri"));
                    }
                    if(db.FinancialRepo.GetTotalForFinancialType(i).Where(m => m.Name == "Diğer Giderler").Count() == 0) 
                    {
                        deneme.Add(Hesapla(i, "Diğer Giderler"));
                    }
                }
                summaryFinancials = db.FinancialRepo.GetTotalForFinancialType(i,1);
                
                foreach (var item in summaryFinancials)
                {
                    item.Month = i;
                    deneme.Add(item);
                }

            }
            return Json(deneme.OrderBy(m=>m.Month), JsonRequestBehavior.AllowGet);
        }
        public SummaryFinancial Hesapla(int i,string name){
            var dene = new SummaryFinancial();
            dene.Name = name;
            dene.Sum = 0;
            dene.Month = i;
            return dene;
        }
    }
}