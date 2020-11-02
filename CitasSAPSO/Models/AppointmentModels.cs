using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasSAPSO.Models
{
    public class AppointmentModels
    {
        public int Id { get; set; }
        public int FunctionaryId { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
        public int ProfessionalId { get; set; }
        public string Patient { get; set; }
        public string State { get; set; }
        public string SubprocessId { get; set; }
        public string Assistance { get; set; }
        public string SubActivityId { get; set; }
        public int Deleted { get; set; }
    }
}