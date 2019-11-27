﻿using PlantRProxy;
using PlantRServ.Model;
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
            Account a = service.FindAccount(User.Identity.Name);
            ViewData["Plants"] = service.GetAccountPersonalPlants(a.ID);
            return View();
        }
    }
}