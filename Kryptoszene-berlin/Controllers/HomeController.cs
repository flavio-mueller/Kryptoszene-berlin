using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kryptoszene_berlin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Survey()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult InterView()
        {
            return View();
        }
    }
}