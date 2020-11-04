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
        public List<AppointmentModels> SearchAppointmentByFiltersAdministrator(AppointmentModels appointment, String initialDate, 
            String finalDate, int process, String dateStatus, int age)
        {
            AppointmentData appointmentData = new AppointmentData();
            return appointmentData.SearchAppointmentByFiltersAdministrator(appointment, initialDate, finalDate, process, dateStatus, age);
        }

        public List<AppointmentModels> GetAppointmentsByFilter()
        {
            AppointmentData appointmentData = new AppointmentData();
            return appointmentData.GetAppointmentsByFilter();
        }
    }
}