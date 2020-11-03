using CitasSAPSO.Data;
using CitasSAPSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasSAPSO.Business
{
    public class AppointmentBusiness
    {

        
        public void RegisterAppointment(AppointmentModels _appointment)
        {           
            AppointmentData appointmentData = new AppointmentData();
            appointmentData.SaveAppointment(_appointment);
        }

        public List<AppointmentModels> SearchAppointmentsForFunctionary(AppointmentModels _appointment)
        {
            AppointmentData appointmentData = new AppointmentData();
            return appointmentData.SearchAppointmentsForFunctionary(_appointment);
        }
        public void DeleteAppointment(AppointmentModels appointment)
        {
            AppointmentData appointmentData = new AppointmentData();
            appointmentData.DeleteAppointment(appointment);
        }
    }
}