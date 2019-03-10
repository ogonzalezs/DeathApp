using Death_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Death_Web.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            IEnumerable<AppointmentWeb> appointList;
            HttpResponseMessage response = GlobalVariables.DeathApiClient.GetAsync("Appointments").Result;
            appointList = response.Content.ReadAsAsync<IEnumerable<AppointmentWeb>>().Result;

            return View(appointList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new AppointmentWeb());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.DeathApiClient.GetAsync("Appointments/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<AppointmentWeb>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(AppointmentWeb appoint)
        {
            if (appoint.IdAppointment == 0)
            {
                HttpResponseMessage response = GlobalVariables.DeathApiClient.PostAsJsonAsync("Appointments", appoint).Result;
                TempData["SuccessMessage"] = "Guardado con Exito";
                return RedirectToAction("Index");
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.DeathApiClient.PutAsJsonAsync("Appointments/"+ appoint.IdAppointment, appoint).Result;
                TempData["SuccessMessage"] = "Actualizado con Exito";
                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.DeathApiClient.DeleteAsync("Appointments/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Borrado con Exito";
            return RedirectToAction("Index");
        }
    }
}