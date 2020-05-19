using mvcRES2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcRES2019.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
            //test
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Agent model, string userName = "", string password = "")
        {
            if (model.UserName == userName && model.Password == password)
            {
                ViewBag.Msg = "Login Successfully";
                return View("Index","Agents");
            }
            else
            {
                ViewBag.Msg = "Login Failed";
            }
            
            return View("Index","Agents");


        }
    }
}