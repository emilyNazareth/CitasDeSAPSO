using CitasSAPSO.Business;
using CitasSAPSO.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Ast.Selectors;

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

        [HttpPost]
        public ActionResult MainFunctionaryRegisterAdministrator(UserModels functionary)
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


        public ActionResult ShowAppointmentDetail(int FunctionaryId, int IdAppointment)
        {
            AppointmentModels appointmentModels = new AppointmentModels();
            appointmentModels.Functionary.Cedula = FunctionaryId;
            appointmentModels.Id = IdAppointment;           
            AppointmentBusiness appointment = new AppointmentBusiness();            
            ViewBag.appointment = appointment.getAppointmentDetail(appointmentModels);
            foreach (AppointmentModels assistance in ViewBag.appointment)
            {
                Debug.WriteLine(assistance.Id);
                Debug.WriteLine(assistance.Functionary.Cedula);
                Debug.WriteLine(assistance.Functionary.Name);
                Debug.WriteLine(assistance.Functionary.FirstLastName);
                Debug.WriteLine(assistance.Functionary.SecondLastName);
                Debug.WriteLine(assistance.Functionary.Gender);
                Debug.WriteLine(assistance.Functionary.NamePlace);
                Debug.WriteLine(assistance.Functionary.NameArea);
                Debug.WriteLine(assistance.Functionary.NameOffice);
                Debug.WriteLine(assistance.Functionary.PersonalPhone);
                Debug.WriteLine(assistance.Functionary.Mail);
                Debug.WriteLine(assistance.Date);
                Debug.WriteLine(assistance.Hour);
                Debug.WriteLine(assistance.Professional.Name);
            }

            return View("AppointmentDetail");
        }
        

        public ActionResult DeleteAppointment(AppointmentModels appointment)
        {
            AppointmentBusiness appointmentBusiness = new AppointmentBusiness();
            appointmentBusiness.DeleteAppointment(appointment);
            return Json("Exitoso");
        }



    }
}