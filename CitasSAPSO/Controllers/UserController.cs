﻿using CitasSAPSO.Business;
using CitasSAPSO.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitasSAPSO.Controllers
{
    public class UserController : Controller
    {

        public ActionResult DashboardAdministrator()
        {
                return View("DashboardAdministrator");      
        }
 
        public ActionResult SearchProfessionalAdministrator()
        {
            UserBusiness UserBusiness = new UserBusiness();
            ViewBag.professionals = UserBusiness.GetListProfessionals();
            return View("SearchProfessionalAdministrator");
        }
        [System.Web.Services.WebMethod]
        public object LoadProfessionalTable()
        {
            UserBusiness UserBusiness = new UserBusiness();
            object json = new { data = UserBusiness.GetListProfessionals() };
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoadProfessionalByProcess(int process)
        {
            UserBusiness UserBusiness = new UserBusiness();
            return Json(UserBusiness.GetProfessionalsByProcess(process));
           // return JsonConvert.SerializeObject(UserBusiness.GetProfessionalsByProcess(process));
        }

        [AllowAnonymous]
        public String SearchProfessionalByFiltersAdministrator(int cedula, String nombre, String apellido)
        {
            UserModels professional = new UserModels();
            professional.Cedula = cedula;
            professional.Name = nombre;
            professional.FirstLastName = apellido;

            UserBusiness administratorBusiness = new UserBusiness();
            //object json = 
            return JsonConvert.SerializeObject(administratorBusiness.SearchProfessionals(professional));

        }
        public ActionResult MainProfessionalRegisterAdministrator()
        {
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            return View("MainProfessionalRegisterAdministrator");
        }
        public ActionResult MainProfessionalUpdateAdministrator()
        {
            int id_professional = Convert.ToInt32(Request.Params["login"]);
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            UserBusiness userBusiness = new UserBusiness();
            ViewBag.professional = userBusiness.GetProfessionalByIdentification(id_professional);
            ViewBag.processProfessional = catalogueBusiness.GetListProcessProfessional(id_professional);
            return View("MainProfessionalUpdateAdministrator");
        }

        public ActionResult ConsultDateAdministrator()
        {
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            ViewBag.offices = catalogueBusiness.GetCatalogueFunctionary("oficina");
            UserBusiness userBusiness = new UserBusiness();
            ViewBag.professional = userBusiness.GetListProfessionals();
            AppointmentBusiness appointmentBusiness = new AppointmentBusiness();
            ViewBag.appointments = appointmentBusiness.GetAppointmentsByFilter();
            return View("ConsultDateAdministrator");
        }


        [HttpPost]
        public ActionResult MainProfessionalRegisterAdministrator(UserModels professional)
        {
            UserBusiness professionalBusiness = new UserBusiness();            
            professionalBusiness.RegisterProfessional(professional);
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            return View("MainProfessionalRegisterAdministrator");
        }
        [HttpPost]
        public ActionResult MainProfessionalUpdateAdministrator(UserModels professional)
        {
            UserBusiness professionalBusiness = new UserBusiness();
            professionalBusiness.ModifyProfessional(professional);
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            return Json("Exitoso");
        }
        [HttpPost]
        public ActionResult MainProfessionalDeleteAdministrator(int id_professional)
        {
            UserBusiness professionalBusiness = new UserBusiness();
            professionalBusiness.DeleteProfessional(id_professional);
            return Json("Exitoso");
        }
                                             
        public ActionResult DashboardProfessional()
        {
            return View();
        }

        public ActionResult ShowDateDetail()
        {
            return View("DateDetailProfessional");
        }

        public ActionResult ProfessionalLogin()
        {
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            catalogueProcess.Table = "oficina";           
            ViewBag.office = catalogueBusiness.GetListCatalogue(catalogueProcess);
            catalogueProcess.Table = "asistencia";
            ViewBag.assistance = catalogueBusiness.GetListCatalogue(catalogueProcess);
            return View("DashboardProfessional");
        }

        [AllowAnonymous]
        public ActionResult ConsultAppointmentFunctionary()
        {
            return View("ConsultAppointmentFunctionary");
        }

        public ActionResult DateDetailFunctionary()
        {
            return View("DateDetailFunctionary");
        }
        [HttpPost]
        public ActionResult SearchAppointmentFunctionary(int _FunctionaryId, int _IdAppointment)
        {
            AppointmentModels appointment = new AppointmentModels();
            appointment.Id = _IdAppointment;
            appointment.Functionary.Cedula = _FunctionaryId;

            AppointmentBusiness appointmentBusiness = new AppointmentBusiness();
            ViewBag.appointments = appointmentBusiness.SearchAppointmentsForFunctionary(appointment);

            return View("ConsultAppointmentFunctionary");
        }

        [AllowAnonymous]
        public ActionResult ValidationLogin(int identification, String password)
        {
            String value;          
            UserModels user = new UserModels();
            user.Cedula = identification;
            user.Password = password;                       
            UserBusiness userBusiness = new UserBusiness();
            value = userBusiness.UserValidation(user);
            if (value.Equals("1"))
            {
                Session["Identification"] = user.Cedula.ToString();
                //Session.Timeout = 15;
              //  Debug.WriteLine("IDENTIFICATION: " + (string)(Session["Identification"]));
                if (GetRol(user).Equals("Profesional"))
                {
                    return Json("Professional");
                }
                else 
                {                    
                    return Json("Administrator");
                }
            }                
            return Json("Datos erroneos");
        }

        public string GetRol(UserModels user)
        {
            String rol;     
            UserBusiness userBusiness = new UserBusiness();
            rol = userBusiness.GetRol(user);                      
            return rol;
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Appointment");
        }

    }
}