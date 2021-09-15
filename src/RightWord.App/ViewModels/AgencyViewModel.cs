using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RightWord.App.ViewModels
{
    public class AgencyViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Field {0} is required")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(200, ErrorMessage = "Field {0} lenght between {2} and {1} caracters.", MinimumLength = 2)]
        public string Name { get; set; }

        [DisplayName("Legal Name")]
        //[Required(ErrorMessage = "Field {0} is required")]
        //[StringLength(200, ErrorMessage = "Field {0} lenght between {2} and {1} caracters.", MinimumLength = 2)]
        public string LegalName { get; set; }

        [DisplayName("Business Owner")]
        //[Required(ErrorMessage = "Field {0} is required")]
        //[StringLength(200, ErrorMessage = "Field {0} lenght between {2} and {1} caracters.", MinimumLength = 2)]
        public string BusinessOwner { get; set; }

        [DisplayName("Business Registration")]
        //[Required(ErrorMessage = "Field {0} is required")]
        //[StringLength(200, ErrorMessage = "Field {0} lenght between {2} and {1} caracters.", MinimumLength = 2)]
        public string BusinessRegistration { get; set; }

        [DisplayName("Address")]
        //[Required(ErrorMessage = "Field {0} is required")]
        //[StringLength(200, ErrorMessage = "Field {0} lenght between {2} and {1} caracters.", MinimumLength = 2)]
        public string Address { get; set; }

        [DisplayName("Zip Code")]
        //[Required(ErrorMessage = "Field {0} is required")]
        //[StringLength(50, ErrorMessage = "Field {0} lenght between {2} and {1} caracters.", MinimumLength = 2)]
        public string ZipCode { get; set; }

        [DisplayName("Country")]
        //[Required(ErrorMessage = "Field {0} is required")]
        public string Country { get; set; }

        [DisplayName("Phone Number")]
        //[Required(ErrorMessage = "Field {0} is required")]
        //[StringLength(40, ErrorMessage = "Field {0} lenght between {2} and {1} caracters.", MinimumLength = 2)]
        public string PhoneNumber { get; set; }
        
        [DisplayName("Student Nationalities")]
        //[Required(ErrorMessage = "Field {0} is required")]
        //[StringLength(300, ErrorMessage = "Field {0} lenght between {2} and {1} caracters.", MinimumLength = 2)]
        public string StudentNationalities { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Registered")]
        public bool Active { get; set; }

        [NotMapped]
        public IEnumerable<StudentViewModel> Students { get; set; }

        public Dictionary<string, string> Countries { get; set; }
    }
}
