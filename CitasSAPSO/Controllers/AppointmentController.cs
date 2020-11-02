using CitasSAPSO.Business;
using CitasSAPSO.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

       

        public ActionResult MainFunctionaryRegisterHome()
        {
            return View("MainFunctionaryRegisterHome");
        }

        [HttpPost]
        public ActionResult MainFunctionaryRegisterHome(UserModels functionary)
        {
            UserBusiness functionaryBusiness = new UserBusiness();
            functionaryBusiness.RegisterFunctionary(functionary);


            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";
            CatalogueBusiness adminBusiness = new CatalogueBusiness();
            ViewBag.process = adminBusiness.GetListCatalogue(catalogueProcess);
            return View("ScheduleDatesHome");
        }

        public ActionResult MainFunctionaryModifyHome()
        {
            string cedula = Request.Params["Cedula"];
            UserBusiness functionaryBusiness = new UserBusiness();
            ViewBag.data = functionaryBusiness.GetFunctionaryByCedula(Int32.Parse(cedula));
            return View("MainFunctionaryModifyHome");
        }

        [HttpPost]
        public ActionResult MainFunctionaryModifyHome(UserModels functionary)
        {
            UserBusiness functionaryBusiness = new UserBusiness();
            functionaryBusiness.ModifyFunctionary(functionary);
            return View("ScheduleDatesHome");
        }

        public ActionResult ScheduleDatesHome()
        {
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
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
    }
}