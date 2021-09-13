using System;
using System.Collections.Generic;
using System.Text;

namespace RightWord.Business.Models
{
    public class Agency : Entity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string LegalName { get; set; }
        public string BusinessOwner { get; set; }
        public string BusinessRegistration { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string StudentNationalities { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Active { get; set; }


        //EF Relations
        public IEnumerable<Student> Students { get; set; }
    }
}
