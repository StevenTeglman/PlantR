using PlantRProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace PlantRMVC2.Controllers
{
    public class UserController : Controller
    {
        public PlantRClient service = new PlantRClient();
        public ActionResult Index()
        {
            ViewBag.Message = "Your User Home page.";
            ViewData["Plants"] = service.GetAccountPersonalPlants(1);//HACK: change to current logged in user.
            return View();
        }
    }
}