using CitasSAPSO.Business;
using CitasSAPSO.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace CitasSAPSO.Controllers
{
    public class AppointmentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult LoginHome()
        {
            return View();
        }

       
        public ActionResult MainFunctionaryRegisterAdministrator()
        {
            CatalogueBusiness appointmentBusiness = new CatalogueBusiness();
            ViewBag.places = appointmentBusiness.GetCatalogueFunctionary("puesto");
            ViewBag.areas = appointmentBusiness.GetCatalogueFunctionary("area");
            ViewBag.offices = appointmentBusiness.GetCatalogueFunctionary("oficina");
            return View("MainFunctionaryRegisterAdministrator");
        }
        public ActionResult MainFunctionaryRegisterHome()
        {
            CatalogueBusiness appointmentBusiness = new CatalogueBusiness();
            ViewBag.places = appointmentBusiness.GetCatalogueFunctionary("puesto");
            ViewBag.areas = appointmentBusiness.GetCatalogueFunctionary("area");
            ViewBag.offices = appointmentBusiness.GetCatalogueFunctionary("oficina");
            return View("MainFunctionaryRegisterHome");
        }

        [HttpPost]
        public ActionResult MainFunctionaryRegisterHome(UserModels functionary)
        {
            UserBusiness functionaryBusiness = new UserBusiness();
            functionaryBusiness.RegisterFunctionary(functionary);
            
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";

            UserBusiness userBusiness = new UserBusiness();
            ViewBag.professional = userBusiness.GetListProfessionals();

            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.subprocess = catalogueBusiness.GetCatalogueFunctionary("subproceso");
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            return View("ScheduleDatesHome");
        }


        public ActionResult MainFunctionaryModifyHome()
        {
            string cedula = Request.Params["Cedula"];
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.places = catalogueBusiness.GetCatalogueFunctionary("puesto");
            ViewBag.areas = catalogueBusiness.GetCatalogueFunctionary("area");
            ViewBag.offices = catalogueBusiness.GetCatalogueFunctionary("oficina");
            UserBusiness functionaryBusiness = new UserBusiness();
            ViewBag.data = functionaryBusiness.GetFunctionaryByCedula(Int32.Parse(cedula));
            return View("MainFunctionaryModifyHome");
        }

        [HttpPost]
        public ActionResult MainFunctionaryModifyHome(UserModels functionary)
        {
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";

            UserBusiness functionaryBusiness = new UserBusiness();
            functionaryBusiness.ModifyFunctionary(functionary);

            UserBusiness userBusiness = new UserBusiness();
            ViewBag.professional = userBusiness.GetListProfessionals();

            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.subprocess = catalogueBusiness.GetCatalogueFunctionary("subproceso");
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            return View("ScheduleDatesHome");
        }


        public ActionResult ScheduleDatesHome()
        {
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";
            CatalogueBusiness appointmentBusiness = new CatalogueBusiness();
            UserBusiness userBusiness = new UserBusiness();

            ViewBag.professional = userBusiness.GetListProfessionals();
            ViewBag.subprocess = appointmentBusiness.GetCatalogueFunctionary("subproceso");
            ViewBag.process = appointmentBusiness.GetListCatalogue(catalogueProcess);
            return View();
        }

        public ActionResult DateConfirmationHome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveAppointment(AppointmentModels _appointment)
        {
            AppointmentBusiness functionaryBusiness = new AppointmentBusiness();
            functionaryBusiness.RegisterAppointment(_appointment);
            return Json("ok");
        }
        [HttpPost]
        public ActionResult SearchAppointmentByFiltersAdministrator(String initialDate, String finalDate, int process, int assistance,
            int office, int identification, char gender, String dateStatus, int consecutive, int age)
        {
            UserModels user = new UserModels();
            user.Cedula = identification;
            user.Gender = gender;
            user.OfficeID = office;
            user.Assistance = assistance;
            AppointmentModels appointment = new AppointmentModels();
            appointment.Functionary = user;
            appointment.Id = consecutive;
            AppointmentBusiness appointmentBusiness = new AppointmentBusiness();
            appointmentBusiness.SearchAppointmentByFiltersAdministrator(appointment, initialDate, finalDate, process, dateStatus, age);
            return Json("ok");
        }
        
    }
}