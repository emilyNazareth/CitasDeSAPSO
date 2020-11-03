using CitasSAPSO.Business;
using CitasSAPSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitasSAPSO.Controllers
{
    public class SecurityController : Controller
    {
        public ActionResult Security()
        {
            SecurityBusiness securityBusiness = new SecurityBusiness();

            ViewBag.roles = securityBusiness.GetListRoles();
            ViewBag.userRoles = securityBusiness.GetListUsersRoles();
            return View("Security");
        }

        public ActionResult ManageRoles()
        {
            SecurityBusiness securityBusiness = new SecurityBusiness();

            ViewBag.roles = securityBusiness.GetListRoles();

            return View("ManageRoles");
        }

        public ActionResult RegisterRole(String roleName)
        {
            SecurityBusiness securityBusiness = new SecurityBusiness();
            RoleModels role = new RoleModels();

            role.Name = roleName;
            securityBusiness.RegisterRole(role);

            return Json("Exitoso");
        }

        public ActionResult ModifyRole(int id, String roleName)
        {
            SecurityBusiness securityBusiness = new SecurityBusiness();
            RoleModels role = new RoleModels();

            role.Name = roleName;
            role.IdRole = id;
            securityBusiness.ModifyRole(role);

            return Json("Exitoso");
        }

        public ActionResult DeleteRole(int id)
        {
            SecurityBusiness securityBusiness = new SecurityBusiness();
            RoleModels role = new RoleModels();

            role.IdRole = id;
            securityBusiness.DeleteRole(role);

            return Json("Exitoso");
        }

        public ActionResult AssignUserRole(int id , int role, String password)
        {
            UserModels user = new UserModels();
            user.Cedula = id;
            user.Role.IdRole = role;
            user.Password = password;

            SecurityBusiness securityBusiness = new SecurityBusiness();
            securityBusiness.AssignUserRole(user);

            return Json("Exitoso");
        }
    }
}