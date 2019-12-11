using PlantRMVC2.Hubs;
using PlantRMVC2.Models;
using PlantRProxy;
using PlantRServ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace PlantRMVC2.Controllers
{
    public class UserController : Controller
    {
        public PlantRClient service = new PlantRClient();
        public ActionResult Index()
        {
                ViewBag.Message = "Your User Home page.";
                Account a = service.FindAccount(User.Identity.Name);
                ViewData["Plants"] = service.GetAccountPersonalPlants(a.ID);
                return View();
        }

        public ActionResult CreatePersonalPlant()
        {
            List<SelectListItem> allPlants = new List<SelectListItem>();
            foreach (Plant plant in service.GetAllPlants())
            {
                SelectListItem sl = new SelectListItem
                {
                    Text = $"{plant.CName} : {plant.SDays} Days",
                    Value = plant.ID.ToString()
                };
                allPlants.Add(sl);
            }
            ViewData["StockPlants"] = allPlants;

            return View(new PersonalPlantModel());
        }
         
        [HttpPost]
        public ActionResult CreatePersonalPlant(PersonalPlantModel pp)
        {
            int aID = service.FindAccount(User.Identity.Name.ToString()).ID;
            service.AddPersonalPlant(Int32.Parse(pp.PId), aID, pp.WDuration, pp.NName);
            
            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public ActionResult UpdatePersonalPlant(int id, int wDuration, string nickname)
        {
            //code the update here
            service.UpdatePersonalPlant(id, wDuration, nickname);

            return Json(new { success = true, message = "Plant updated successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemovePersonalPlant(int id)
        {
            bool check = service.RemovePersonalPlant(id);

            return Json(new { success = check, message = "Plant removed successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult WaterPersonalPlant(int id)
        {
            bool check = service.UpdatePersonalPlantDates(id);

            return Json(new { success = check, message = "Plant Watered successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}