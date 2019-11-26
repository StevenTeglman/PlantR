using PlantRMVC2.PlantRRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PlantRMVC2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserHome()
        {
            ViewBag.Message = "Your User Home page.";
            ViewData["Plants"] = new List<PersonalPlant>
            {
                new PersonalPlant
                {
                ID=1,
                AId=99,
                CName = "Rose",
                Description = "Apparently everyone has its thorn, or something",
                ImageURL = "http://www.flowerpicturesfromMatesmum.com",
                LName = "Rosa",
                SDays = 7,
                LastWatered = DateTime.Now,
                NextWatered= DateTime.Now.AddDays(3),
                NName="Roseyrose",
                WDuration=3,
                },
                new PersonalPlant
                {
                ID = 2,
                AId = 99,
                CName = "Tulip",
                Description = "Tulipingn",
                ImageURL = "http://www.flowerpicturesfromMatesmum.com",
                LName = "Tulipa",
                SDays = 7,
                LastWatered = DateTime.Now,
                NextWatered = DateTime.Now.AddDays(3),
                NName = "Tilly",
                WDuration = 3,
                },
                new PersonalPlant
                {
                    ID = 3,
                AId = 99,
                CName = "Magnolia",
                Description = "Magdelene died for this",
                ImageURL = "http://www.flowerpicturesfromMatesmum.com",
                LName = "Magni",
                SDays = 7,
                LastWatered = DateTime.Now,
                NextWatered = DateTime.Now.AddDays(3),
                NName = "Maggy",
                WDuration = 3,
                }

            };
            
            return View();
        }
    }
}