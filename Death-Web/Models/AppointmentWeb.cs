using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Death_Web.Models
{
    public class AppointmentWeb
    {


        public int IdAppointment { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        public System.DateTime AppointmentDateTime { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int Hour { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Email { get; set; }


        public string Note { get; set; }
    }
}