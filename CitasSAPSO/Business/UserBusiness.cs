using CitasSAPSO.Data;
using CitasSAPSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasSAPSO.Business
{
    public class UserBusiness
    {

        
        public List<UserModels> GetListProfessionals()
        {
            UserData professionalData = new UserData();
            return professionalData.GetListProfessionals();
        }

        public List<UserModels> SearchProfessionals(UserModels professional)
        {
            UserData professionalData = new UserData();
            return professionalData.SearchProfessional(professional);
        }

        
        public void RegisterFunctionary(UserModels _functionary)
        {
            UserData professionalData = new UserData();
            professionalData.SaveFunctionary(_functionary);
        }

      

        public List<UserModels> GetFunctionaryByCedula(int _cedula)
        {
            UserData functionaryData = new UserData();
            return functionaryData.GetFunctionary(_cedula);
        }

        public void ModifyFunctionary(UserModels _functionary)
        {
            UserData functionaryData = new UserData();
            functionaryData.ModifyFunctionary(_functionary);
        }

        UserData professionalData = new UserData();
        public void RegisterProfessional(UserModels _professional)
        {
            professionalData.RegisterProfessional(_professional);
        }
        public void ModifyProfessional(UserModels _professional)
        {
            professionalData.ModifyProfessional(_professional);
        }
        public List<UserModels> GetProfessionalByIdentification(int id_professional)
        {
            return professionalData.GetProfessionalByIdentification(id_professional);
        }
        public List<CatalogueModels> GetListProcessProfessional(int id_professional)
        {
            return professionalData.GetListProcessProfessional(id_professional);
        }
        public void DeleteProfessional(int id_professional)
        {
            professionalData.DeleteProfessional(id_professional);
        }

        public String UserValidation(UserModels user)
        {
            UserData userData = new UserData();
            return userData.UserValidation(user);
        }

        public String GetRol(UserModels user)
        {
            UserData userData = new UserData();
            return userData.GetRol(user);
        }
    }
}