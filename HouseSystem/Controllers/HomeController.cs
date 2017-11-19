using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HouseSystem.DAL;
using HouseSystem.Service;
namespace HouseSystem.Controllers
{
    public class HomeController : Controller
    {
        private HouseContext db = new HouseContext();

        public ActionResult Index2()
        {
         //   CommonService.initialData(db);
            return View("index");
        }
        public ActionResult Index()
        {
            return View("login");
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