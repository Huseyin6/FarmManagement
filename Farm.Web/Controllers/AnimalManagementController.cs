using Farm.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web.Controllers
{
    public class AnimalManagementController : Controller
    {
        public AnimalManagementController()
        {
            UnitOfWork unitOfWork = new UnitOfWork(new MainContext());
            unitOfWork.CowsRepository.Add(new Data.Entities.Cow() { Id = 1, Name = "Cow1", BirthDate = DateTime.Now, EaringNo = "TR 06 1111", State = 1, IsLactation = true, IsPregnant = false, StateChangeDate = DateTime.Now });
            unitOfWork.Complete();    
            }
        // GET: AnimalManagement
        public ActionResult Cows()
        {
            return View();
        }
        public ActionResult Calves(){
            return View();
        }
        public ActionResult Heifers()
        {
            return View();
        }
        public ActionResult Steers()
        {
            return View();
        }
    }
}