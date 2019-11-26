using PlantRProxy;
using PlantRServ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PlantRMVC2.Controllers
{
    
    public class HomeController : Controller
    {
        public PlantRClient service = new PlantRClient();

        public ActionResult Index()
        {
            
            Console.WriteLine();
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

        

    }
}