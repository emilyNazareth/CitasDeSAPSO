using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasSAPSO.Models
{
    public class UserModels
    {

        public int Cedula { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string PersonalPhone { get; set; }
        public string RoomPhone { get; set; }
        public string Birthday { get; set; }
        public char Gender { get; set; }
        public string Scholarship { get; set; }
        public string Province { get; set; }
        public string Canton { get; set; }
        public string District { get; set; }
        public string CivilStatus { get; set; }
        public string Address { get; set; }     
        public int OfficeID { get; set; }
        public int AreaID { get; set; }
        public int PlaceID { get; set; }
        public string NameOffice { get; set; }
        public string NameArea { get; set; }
        public string NamePlace { get; set; }
        public int ProfessionalId { get; set; }
        public int PlaceNumber { get; set; }
        public string EmergencyContact { get; set; }
        public string Specialty { get; set; }
        public string SchoolCode { get; set; }
        public int Status { get; set; }
        public int[] Process { get; set; }
        public int EmergencyContactNumber { get; set; }

        public string OficePhone { get; set; }
        public string Mail { get; set; }
        public string IdPlaca { get; set; }
        public int Assistance { get; set; }
        public string PortationExpirationDay { get; set; }
        public string AdmissionDate { get; set; }
        public RoleModels role { get; set; }
    }
}