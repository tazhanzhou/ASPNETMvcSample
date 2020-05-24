using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Controllers
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

        public string HelloWorld(string firstName, string lastName)
        {
            return $"Hello World from {firstName} {lastName}!";
        }

        public ActionResult GetUser(int number)
        {
            IList<int> myList = new List<int> { 1, 2, 3, 4 };

            ViewBag.UserMessage = $"Hello from the User_{number}";
            ViewBag.MyList = myList;

            return RedirectToAction("Contact");

        }
    }
}