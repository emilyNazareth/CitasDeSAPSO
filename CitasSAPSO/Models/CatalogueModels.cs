using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasSAPSO.Models
{
    public class CatalogueModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Deleted { get; set; }
        public string Table { get; set; }
        public int FatherID { get; set; }

    }
}