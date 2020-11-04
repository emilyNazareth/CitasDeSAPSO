using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasSAPSO.Models
{
    public class AppointmentModels
    {
        public int Id { get; set; }
        public UserModels Functionary { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public UserModels Professional { get; set; }
        public string Patient { get; set; }
        public string State { get; set; }
        public CatalogueModels SubProcess { get; set; }
        public CatalogueModels Assistance { get; set; }
        public CatalogueModels SubActivity { get; set; }
        public int Deleted { get; set; }
        public string Justification { get; set; }
        public AppointmentModels()
        {
            Functionary = new UserModels();
            Professional = new UserModels();
            SubProcess = new CatalogueModels();
            SubActivity = new CatalogueModels();
            Assistance = new CatalogueModels();
            SubActivity = new CatalogueModels();
                
        }
    }
}