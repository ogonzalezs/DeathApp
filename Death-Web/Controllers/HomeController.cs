using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Death_Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {

            //http://localhost:51196
            //var httpClient = new HttpClient();
            //var json = await httpClient.GetStringAsync("http://localhost:51196/api/Appointments");
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