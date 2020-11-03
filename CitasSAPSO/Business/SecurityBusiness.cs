using CitasSAPSO.Data;
using CitasSAPSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasSAPSO.Business
{
    public class SecurityBusiness
    {

        public List<RoleModels> GetListRoles()
        {
            SecurityData securityData = new SecurityData();
            return securityData.GetListRoles();

        }

        public List<UserModels> GetListUsersRoles()
        {
            SecurityData securityData = new SecurityData();
            return securityData.GetListUsersRoles();
        }

        public void AssignUserRole(UserModels user)
        {
            SecurityData securityData = new SecurityData();
            securityData.AssignUserRole(user);
        }

        public void RegisterRole(RoleModels role)
        {
            SecurityData securityData = new SecurityData();
            securityData.RegisterRole(role);
        }

        public void ModifyRole(RoleModels role)
        {
            SecurityData securityData = new SecurityData();
            securityData.ModifyRole(role);
        }
        public void DeleteRole(RoleModels role)
        {
            SecurityData securityData = new SecurityData();
            securityData.DeleteRole(role);
        }

    }
}