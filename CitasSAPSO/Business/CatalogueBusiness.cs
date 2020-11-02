using CitasSAPSO.Data;
using CitasSAPSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasSAPSO.Business
{
    public class CatalogueBusiness
    {
        public List<CatalogueModels> GetListCatalogue(CatalogueModels _catalogue)
        {
            CatalogueData adminData = new CatalogueData();
            return adminData.GetListCatalogue(_catalogue);

        }

        public void RegisterCatalogueItem(CatalogueModels _catalogue)
        {
            CatalogueData adminData = new CatalogueData();
            adminData.RegisterCatalogueItems(_catalogue);
        }

        public void ModifyCatalogueItems(CatalogueModels _catalogue)
        {
            CatalogueData adminData = new CatalogueData();
            adminData.ModifyCatalogueItems(_catalogue);
        }
        public void DeleteCatalogueItems(CatalogueModels _catalogue)
        {
            CatalogueData adminData = new CatalogueData();
            adminData.DeleteCatalogueItems(_catalogue);
        }
        public List<CatalogueModels> GetCatalogueFunctionary(string _catalogue)
        {
            CatalogueData catalogue = new CatalogueData();
            return catalogue.GetCatalogueFunctionary(_catalogue);
        }

    }
}