using CitasSAPSO.Business;
using CitasSAPSO.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Ast.Selectors;

namespace CitasSAPSO.Controllers
{
    public class AppointmentController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult LoginHome()
        {
            return View();
        }

       
        public ActionResult MainFunctionaryRegisterAdministrator()
        {
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.places = catalogueBusiness.GetCatalogueFunctionary("puesto");
            ViewBag.areas = catalogueBusiness.GetCatalogueFunctionary("area");
            ViewBag.offices = catalogueBusiness.GetCatalogueFunctionary("oficina");
            ViewBag.assistance = catalogueBusiness.GetCatalogueFunctionary("asistencia");
            return View("MainFunctionaryRegisterAdministrator");
        }

        [HttpPost]
        public ActionResult MainFunctionaryRegisterAdministrator(UserModels functionary)
        {
            //UserBusiness functionaryBusiness = new UserBusiness();
            //functionaryBusiness.RegisterFunctionary(functionary);

            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";

            UserBusiness userBusiness = new UserBusiness();
            ViewBag.professional = userBusiness.GetListProfessionals();

            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.subprocess = catalogueBusiness.GetCatalogueFunctionary("subproceso");
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            Session["functionary"] = functionary;
            Session["email"] = functionary.Mail;
            ViewBag.functionary = functionary;
            return View("ScheduleDatesHome");
        }

        [AllowAnonymous]
        public ActionResult MainFunctionaryRegisterHome()
        {
            CatalogueBusiness appointmentBusiness = new CatalogueBusiness();
            ViewBag.places = appointmentBusiness.GetCatalogueFunctionary("puesto");
            ViewBag.areas = appointmentBusiness.GetCatalogueFunctionary("area");
            ViewBag.offices = appointmentBusiness.GetCatalogueFunctionary("oficina");
            return View("MainFunctionaryRegisterHome");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult MainFunctionaryRegisterHome(UserModels functionary)
        {
           // UserBusiness functionaryBusiness = new UserBusiness();
           // functionaryBusiness.RegisterFunctionary(functionary);
            
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";

            UserBusiness userBusiness = new UserBusiness();
            ViewBag.professional = userBusiness.GetListProfessionals();

            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.subprocess = catalogueBusiness.GetCatalogueFunctionary("subproceso");
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            Session["functionary"] = functionary;
            Session["email"] = functionary.Mail;
            ViewBag.functionary = functionary;
            return View("ScheduleDatesHome");
        }

        [AllowAnonymous]
        public ActionResult MainFunctionaryModifyHome()
        {
            string cedula = Request.Params["Cedula"];
            Session["idAppointment"] = Request.Params["id"];
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.places = catalogueBusiness.GetCatalogueFunctionary("puesto");
            ViewBag.areas = catalogueBusiness.GetCatalogueFunctionary("area");
            ViewBag.offices = catalogueBusiness.GetCatalogueFunctionary("oficina");
            ViewBag.assistance = catalogueBusiness.GetCatalogueFunctionary("asistencia");
            UserBusiness functionaryBusiness = new UserBusiness();
            ViewBag.data = functionaryBusiness.GetFunctionaryByCedula(Int32.Parse(cedula));
            return View("MainFunctionaryModifyHome");
        }

        [AllowAnonymous]
        public ActionResult MainFunctionaryModifyAdministrator()
        {
            UserModels functionary = new UserModels();
            functionary = (UserModels)Session["functionary"];
            
            //string cedula = Request.Params["Cedula"];
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.places = catalogueBusiness.GetCatalogueFunctionary("puesto");
            ViewBag.areas = catalogueBusiness.GetCatalogueFunctionary("area");
            ViewBag.offices = catalogueBusiness.GetCatalogueFunctionary("oficina");
            ViewBag.assistance = catalogueBusiness.GetCatalogueFunctionary("asistencia");
            UserBusiness functionaryBusiness = new UserBusiness();
            ViewBag.data = functionaryBusiness.GetFunctionaryByCedula(functionary.Cedula);
            return View("MainFunctionaryModifyHome");
        }

        [HttpPost]
        [AllowAnonymous]
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
            Session["functionary"] = functionary;
            Session["email"] = functionary.Mail;
            ViewBag.functionary = functionary;
            return View("ScheduleDatesAdministrator");
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        public ActionResult ScheduleDatesAdministrator()
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

        [AllowAnonymous]
        public ActionResult DateConfirmationHome()
        {
            ViewBag.appointment = Session["appointment"];
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SaveAppointment(AppointmentModels _appointment)
        {
            UserBusiness functionaryBusiness = new UserBusiness();
            functionaryBusiness.RegisterFunctionary((UserModels)Session["functionary"]);
            CreateMail(_appointment);
            AppointmentBusiness appointmentBusiness = new AppointmentBusiness();
            appointmentBusiness.RegisterAppointment(_appointment);
            
            Session["appointment"] = _appointment;
            return Json("ok");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult UpdateAppointment(AppointmentModels _appointment)
        {
            UserBusiness functionaryBusiness = new UserBusiness();
            functionaryBusiness.RegisterFunctionary((UserModels)Session["functionary"]);
            CreateMail(_appointment);
            AppointmentBusiness appointmentBusiness = new AppointmentBusiness();
            string idAppointment = (string)Session["idAppointment"];
            Debug.WriteLine("iiiiiiiiiiiiiiiiiiiiiiiiddddddddddddddddddddddddddddd: "+idAppointment);
            appointmentBusiness.UpdateAppointment(_appointment, Int32.Parse(idAppointment));

            Session["appointment"] = _appointment;
            return Json("ok");
        }

        [HttpPost]
        public String ConsultDateAdministrator(String initialDate, String finalDate, int process, int assistance,
            int office, int identification, char gender, String dateStatus, int consecutive, int age, int professional)
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
            //appointmentBusiness.SearchAppointmentByFiltersAdministrator(appointment, initialDate, finalDate, process, dateStatus, age, age);
            return JsonConvert.SerializeObject(appointmentBusiness.SearchAppointmentByFiltersAdministrator(appointment, initialDate, finalDate, process, dateStatus, age, professional));
            
        }

        [AllowAnonymous]
        public ActionResult ShowAppointmentDetailPost()
        {
            string FunctionaryId = Request.Params["cedula"]; 
            string IdAppointment = Request.Params["id"];
            AppointmentModels appointmentModels = new AppointmentModels();
            appointmentModels.Functionary.Cedula = Int32.Parse(FunctionaryId);
            appointmentModels.Id = Int32.Parse(IdAppointment);
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


        [AllowAnonymous]
        public ActionResult ShowAppointmentDetail(int FunctionaryId, int IdAppointment)
        {
            AppointmentModels appointmentModels = new AppointmentModels();
            appointmentModels.Functionary.Cedula = FunctionaryId;
            appointmentModels.Id = IdAppointment;
            Debug.WriteLine("ID FUNCTIONARY" + FunctionaryId);
            Debug.WriteLine("IDAPPOINTMENT" + IdAppointment);
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

        [AllowAnonymous]
        public ActionResult DeleteAppointment(AppointmentModels appointment)
        {
            AppointmentBusiness appointmentBusiness = new AppointmentBusiness();
            appointmentBusiness.DeleteAppointment(appointment);
            return Json("Exitoso");
        }


        public void CreateMail(AppointmentModels appointment)
        {
            CatalogueController catalogue = new CatalogueController();
            int process = catalogue.GetProcessBySubprocess(appointment.SubProcess.ID);

            string email = (string)Session["email"];

            MailModels mail;
            String message = "Su cita ha sido programada con éxito. \n " +
                    "\n\tRESUMEN DE CITA:\n" +
                    "Fecha: " + appointment.Date + "\n" +
                    "Hora: " + appointment.Hour + "\n" +
                    "Paciente: " + appointment.Functionary.Cedula +
                    "\n\n Para cualquier consulta comuniquese al teléfono 2295-4181," +
                    " al correo sapso@poder-judicial.go.cr o a nuestro sitio web de citas para cancelar o modificar su cita";
            switch (process)
            {
                case 1:
                    mail = new MailModels("DAVID.ALVARADOELIZONDO@ucr.ac.cr", email,
                    "ESTE CORREO ES PARA CONFIRMAR SU CITA DE PROCESO CLINICO EN SAPSO \n" + message,
                    "CONFIRMACION CITA CLÍNICO", 0);
                    break;
                case 2:
                    mail = new MailModels("DAVID.ALVARADOELIZONDO@ucr.ac.cr", email,
                    "ESTE CORREO ES PARA CONFIRMAR SU CITA DE PROCESO INCIDENTE CRÍTICO EN SAPSO\n" + message +
                    "IMPORTANTE Complete el formulario adjunto y preséntelo el día de su cita",
                    "CONFIRMACION CITA INCIDENTES CRITICOS", 2);
                    break;
                case 3:
                     mail = new MailModels("DAVID.ALVARADOELIZONDO@ucr.ac.cr", email,
                    "ESTE CORREO ES PARA CONFIRMAR SU CITA DE PROCESO ARMAS EN SAPSO \n" + message,
                    "CONFIRMACION DE CITA", 0);
                    break;
                case 4:
                     mail = new MailModels("DAVID.ALVARADOELIZONDO@ucr.ac.cr", email,
                    "ESTE CORREO ES PARA CONFIRMAR SU CITA DE PROCESO CHARLAS EN SAPSO \n" + message,
                    "CONFIRMACION DE CITA", 0);
                    break;
                case 5:
                    mail = new MailModels("DAVID.ALVARADOELIZONDO@ucr.ac.cr", email,
                    "ESTE CORREO ES PARA CONFIRMAR SU CITA DE PROCESO CAPITULO \"V\" EN SAPSO \n" + message+
                    "IMPORTANTE: Complete el formulario adjunto y preséntelo el día de su cita",
                    "CONFIRMACION CITA CAPITULO V", 1);
                    break;
                default:
                    mail = new MailModels("DAVID.ALVARADOELIZONDO@ucr.ac.cr", email,
                    "ESTE CORREO ES PARA CONFIRMAR SU CITA EN SAPSO \n" + message, "CONFIRMACION DE CITA", 0);
                    break;
            }
            mail.SendMail();

        }

    }
}