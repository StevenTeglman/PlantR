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

        [HttpPost]
        public ActionResult UpdatePersonalPlant(int id, int wDuration, string nickname)
        {
            //code the update here
            service.UpdatePersonalPlant(id, wDuration, nickname);

            return Json(new { success = true, message = "Plant updated successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}