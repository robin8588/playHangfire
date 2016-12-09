using Hangfire;
using Hangfire.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace playHangfire.Controllers
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
            BackgroundJob.Enqueue(() => Debug.WriteLine("hello world") );
            RecurringJob.AddOrUpdate("Hi",()=> Debug.WriteLine("Hi"),Cron.Minutely);
            return View();
        }
    }
}