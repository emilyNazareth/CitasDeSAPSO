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
        public void UpdateAppointment(AppointmentModels _appointment, int idAppointment)
        {
            AppointmentData appointmentData = new AppointmentData();
            appointmentData.UpdateAppointment(_appointment, idAppointment);
        }

        public List<AppointmentModels> SearchAppointmentsForFunctionary(AppointmentModels _appointment)
        {
            AppointmentData appointmentData = new AppointmentData();
            return appointmentData.SearchAppointmentsForFunctionary(_appointment);
        }

        public List<AppointmentModels> SearchAppointmentsForProfesional(AppointmentModels _appointment, string initialDate, string finalDate, int age)
        {
            AppointmentData appointmentData = new AppointmentData();
            return appointmentData.SearchAppointmentsForProfesional(_appointment, initialDate, finalDate, age);
           
        }


        public List<AppointmentModels> SearchAppointmentByFiltersAdministrator(AppointmentModels appointment, String initialDate, 
            String finalDate, int process, String dateStatus, int age, int professional)
        {
            AppointmentData appointmentData = new AppointmentData();
            return appointmentData.SearchAppointmentByFiltersAdministrator(appointment, initialDate, finalDate, process, dateStatus, age, professional);
        }

        public List<AppointmentModels> GetAppointmentsByFilter()
        {
            AppointmentData appointmentData = new AppointmentData();
            return appointmentData.GetAppointmentsByFilter();
        }



        public List<AppointmentModels> getAppointmentDetail(AppointmentModels _appointment)
        {
            AppointmentData appointmentData = new AppointmentData();
            return appointmentData.getAppointmentDetail(_appointment);
        }
        

        public void DeleteAppointment(AppointmentModels appointment)
        {
            AppointmentData appointmentData = new AppointmentData();
            appointmentData.DeleteAppointment(appointment);
        }
        public List<AppointmentModels> getProfessinalScheldule(int professionalId)
        {
            AppointmentData appointmentData = new AppointmentData();
            return appointmentData.getProfessinalScheldule(professionalId);
        }



    }
}