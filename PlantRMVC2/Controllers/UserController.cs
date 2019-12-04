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
            // Make a thing to get a list of all the plants, I guess? I don't fucking know. I mean how the fuck are you supposed to pass
            // in more than one model? I guess with a ViewData things like BigDickSaif did. btw he's gay. 
            //dont be rude - saif
            ViewData["StockPlants"] = service.GetAllPlants();
            //hopefully something like this^^^^-saif
            return View();
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