using CitasSAPSO.Business;
using CitasSAPSO.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitasSAPSO.Controllers
{
    [AllowAnonymous]
    public class CatalogueController : Controller
    {
        // GET: Catalogue
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult RegisterProcessAdministrator(String description)

        {
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";
            catalogueProcess.Name = description;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.RegisterCatalogueItem(catalogueProcess);
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            return Json("Exitoso");
        }

        public ActionResult ModifyProcessAdministrator(int id, String description)
        {
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";
            catalogueProcess.ID = id;
            catalogueProcess.Name = description;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.ModifyCatalogueItems(catalogueProcess);
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            return Json("Exitoso");
        }

        public ActionResult DeleteProcessAdministrator(int id)
        {
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";
            catalogueProcess.ID = id;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.DeleteCatalogueItems(catalogueProcess);
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            return Json("Exitoso");
        }
        public ActionResult RegisterSubprocessAdministrator(String description, int father)
        {
            CatalogueModels catalogue = new CatalogueModels();
            catalogue.Table = "subproceso";
            catalogue.Name = description;
            catalogue.FatherID = father;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.RegisterCatalogueItem(catalogue);
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogue);
            return Json("Exitoso");
        }

        public ActionResult ModifySubprocessAdministrator(int id, String description, int father)
        {
            CatalogueModels catalogue = new CatalogueModels();
            catalogue.Table = "subproceso";
            catalogue.ID = id;
            catalogue.Name = description;
            catalogue.FatherID = father;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.ModifyCatalogueItems(catalogue);
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogue);
            return Json("Exitoso");
        }

        public ActionResult DeleteSubprocessAdministrator(int id)
        {
            CatalogueModels catalogue = new CatalogueModels();
            catalogue.Table = "subproceso";
            catalogue.ID = id;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.DeleteCatalogueItems(catalogue);
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogue);
            return Json("Exitoso");
        }
        public ActionResult RegisterActivityAdministrator(String description)
        {
            CatalogueModels catalogue = new CatalogueModels();
            catalogue.Table = "actividad";
            catalogue.Name = description;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.RegisterCatalogueItem(catalogue);
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogue);
            return Json("Exitoso");
        }

        public ActionResult ModifyActivityAdministrator(int id, String description)
        {
            CatalogueModels catalogue = new CatalogueModels();
            catalogue.Table = "actividad";
            catalogue.ID = id;
            catalogue.Name = description;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.ModifyCatalogueItems(catalogue);
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogue);
            return Json("Exitoso");
        }
        public ActionResult DeleteActivityAdministrator(int id)
        {
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "actividad";
            catalogueProcess.ID = id;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.DeleteCatalogueItems(catalogueProcess);
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            return Json("Exitoso");
        }
        public ActionResult RegisterSubactivityAdministrator(String description, int father)
        {
            CatalogueModels catalogue = new CatalogueModels();
            catalogue.Table = "Subactividad";
            catalogue.Name = description;
            catalogue.FatherID = father;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.RegisterCatalogueItem(catalogue);
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogue);
            return Json("Exitoso");
        }

        public ActionResult ModifySubactivityAdministrator(int id, String description, int father)
        {
            CatalogueModels catalogue = new CatalogueModels();
            catalogue.Table = "Subactividad";
            catalogue.ID = id;
            catalogue.Name = description;
            catalogue.FatherID = father;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.ModifyCatalogueItems(catalogue);
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogue);
            return Json("Exitoso");
        }

        public ActionResult DeleteSubactivityAdministrator(int id)
        {
            CatalogueModels catalogue = new CatalogueModels();
            catalogue.Table = "Subactividad";
            catalogue.ID = id;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.DeleteCatalogueItems(catalogue);
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogue);
            return Json("Exitoso");
        }

        public ActionResult RegisterPlaceAdministrator(String description)
        {
            CatalogueModels cataloguePlace = new CatalogueModels();
            cataloguePlace.Table = "puesto";
            cataloguePlace.Name = description;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.RegisterCatalogueItem(cataloguePlace);
            ViewBag.process = catalogueBusiness.GetListCatalogue(cataloguePlace);
            return Json("Exitoso");
        }

        public ActionResult ModifyPlaceAdministrator(int id, String description)
        {
            CatalogueModels cataloguePlace = new CatalogueModels();
            cataloguePlace.ID = id;
            cataloguePlace.Name = description;
            cataloguePlace.Table = "puesto";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.ModifyCatalogueItems(cataloguePlace);
            return Json("Exitoso");
        }

        public ActionResult DeletePlaceAdministrator(int id)
        {
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "puesto";
            catalogueProcess.ID = id;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.DeleteCatalogueItems(catalogueProcess);
            return Json("Exitoso");
        }


        public ActionResult RegisterAreaAdministrator(String description)
        {
            CatalogueModels catalogueArea = new CatalogueModels();
            catalogueArea.Table = "area";
            catalogueArea.Name = description;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.RegisterCatalogueItem(catalogueArea);
            return Json("Exitoso");
        }

        public ActionResult ModifyAreaAdministrator(int id, String description)
        {
            CatalogueModels cataloguePlace = new CatalogueModels();
            cataloguePlace.ID = id;
            cataloguePlace.Name = description;
            cataloguePlace.Table = "area";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.ModifyCatalogueItems(cataloguePlace);
            return Json("Exitoso");
        }

        public ActionResult DeleteAreaAdministrator(int id)
        {
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "area";
            catalogueProcess.ID = id;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.DeleteCatalogueItems(catalogueProcess);
            return Json("Exitoso");
        }


        public ActionResult RegisterOfficeAdministrator(String description)
        {
            CatalogueModels catalogueOficce = new CatalogueModels();
            catalogueOficce.Table = "oficina";
            catalogueOficce.Name = description;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.RegisterCatalogueItem(catalogueOficce);
            return Json("Exitoso");
        }

        public ActionResult ModifyOfficeAdministrator(int id, String description)
        {
            CatalogueModels cataloguePlace = new CatalogueModels();
            cataloguePlace.ID = id;
            cataloguePlace.Name = description;
            cataloguePlace.Table = "oficina";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.ModifyCatalogueItems(cataloguePlace);
            return Json("Exitoso");
        }


        public ActionResult DeleteOfficeAdministrator(int id)
        {
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "oficina";
            catalogueProcess.ID = id;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.DeleteCatalogueItems(catalogueProcess);
            return Json("Exitoso");
        }


        public ActionResult RegisterAssistanceAdministrator(String description)
        {
            CatalogueModels catalogueAssitance = new CatalogueModels();
            catalogueAssitance.Table = "asistencia";
            catalogueAssitance.Name = description;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.RegisterCatalogueItem(catalogueAssitance);
            return Json("Exitoso");
        }

        public ActionResult ModifyAssistanceAdministrator(int id, String description)
        {
            CatalogueModels cataloguePlace = new CatalogueModels();
            cataloguePlace.ID = id;
            cataloguePlace.Name = description;
            cataloguePlace.Table = "asistencia";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.ModifyCatalogueItems(cataloguePlace);
            return Json("Exitoso");
        }

        public ActionResult DeleteAssistanceAdministrator(int id)
        {
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "asistencia";
            catalogueProcess.ID = id;
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            catalogueBusiness.DeleteCatalogueItems(catalogueProcess);
            return Json("Exitoso");
        }


        public ActionResult ManageProcessAdministrator()
        {
            CatalogueModels catalogueProcess = new CatalogueModels();
            catalogueProcess.Table = "proceso";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            return View("ManageProcessAdministrator");
        }
        public ActionResult ManageSubProcessAdministrator()
        {

            CatalogueModels catalogueProcess = new CatalogueModels();
            CatalogueModels catalogueSubProcess = new CatalogueModels();

            catalogueProcess.Table = "proceso";
            catalogueSubProcess.Table = "subproceso";

            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();

            ViewBag.process = catalogueBusiness.GetListCatalogue(catalogueProcess);
            ViewBag.subprocess = catalogueBusiness.GetListCatalogue(catalogueSubProcess);

            return View("ManageSubProcessAdministrator");
        }
        public ActionResult ManageActivityAdministrator()
        {
            CatalogueModels catalogueActivity = new CatalogueModels();
            catalogueActivity.Table = "actividad";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.activity = catalogueBusiness.GetListCatalogue(catalogueActivity);
            return View("ManageActivityAdministrator");
        }
        public ActionResult ManageSubActivityAdministrator()
        {
            CatalogueModels catalogueActivity = new CatalogueModels();
            CatalogueModels catalogueSubActivity = new CatalogueModels();

            catalogueActivity.Table = "actividad";
            catalogueSubActivity.Table = "subactividad";

            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();

            ViewBag.activity = catalogueBusiness.GetListCatalogue(catalogueActivity);
            ViewBag.subactivity = catalogueBusiness.GetListCatalogue(catalogueSubActivity);

            return View("ManageSubActivityAdministrator");
        }
        public ActionResult ManagePlaceAdministrator()
        {            
            CatalogueModels cataloguePlace = new CatalogueModels();
            cataloguePlace.Table = "puesto";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.places = catalogueBusiness.GetListCatalogue(cataloguePlace);
            return View("ManagePlaceAdministrator");
        }
        public ActionResult ManageAreaAdministrator()
        {
            CatalogueModels catalogueArea = new CatalogueModels();
            catalogueArea.Table = "area";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.areas = catalogueBusiness.GetListCatalogue(catalogueArea);
            return View("ManageAreaAdministrator");
        }
        public ActionResult ManageOfficeAdministrator()
        {
            CatalogueModels catalogueOffice = new CatalogueModels();
            catalogueOffice.Table = "oficina";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.offices = catalogueBusiness.GetListCatalogue(catalogueOffice);
            return View("ManageOfficeAdministrator");
        }
        public ActionResult ManageAssistanceAdministrator()
        {
            CatalogueModels catalogueOffice = new CatalogueModels();
            catalogueOffice.Table = "asistencia";
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            ViewBag.assistance = catalogueBusiness.GetListCatalogue(catalogueOffice);
            return View("ManageAssistanceAdministrator");
        }

        [HttpPost]
        public ActionResult GetSubprocessListByProcess(int process)
        {
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            return Json(catalogueBusiness.GetSubprocessListByProcess(process));
            // return JsonConvert.SerializeObject(UserBusiness.GetProfessionalsByProcess(process));
        }

        [HttpPost]
        public ActionResult GetAppointmensQuantityFirstSemester()
        {
            CatalogueBusiness catalogueBusiness = new CatalogueBusiness();
            return Json(catalogueBusiness.GetAppointmensQuantityFirstSemester());
            // return JsonConvert.SerializeObject(catalogueBusiness.GetAppointmensQuantityFirstSemester());
        }

    }
}