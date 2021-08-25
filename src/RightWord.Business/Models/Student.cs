using RightWord.Business.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RightWord.Business.Models
{
    public class Student : Entity
    {
        public Guid AgencyId { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Passport { get; set; }
        public string PassportImage { get; set; }
        public string Country { get; set; }
        public string NativeLanguage { get; set; }
        public Session Session { get; set; }
        public int Duration { get; set; }
        public CourseType CourseType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime Dob { get; set; }
        public AccomodationType Accomodation { get; set; }
        public int AccomodationDuration { get; set; }
        public bool Active { get; set; }

        //EF Relations
        public Agency Agency { get; set; }
        public IEnumerable<Document> Documents { get; set; }
    }
}
