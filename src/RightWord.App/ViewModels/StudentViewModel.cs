using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace RightWord.App.ViewModels
{
    public class StudentViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Agency")]
        [Required(ErrorMessage = "Field {0} is required")]
        public Guid AgencyId { get; set; }
        
        [DisplayName("Email")]
        [Required(ErrorMessage = "Field {0} is required")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(200, ErrorMessage = "Field {0} lenght between {2} and {1} caracters.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [DisplayName("Surname")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(200, ErrorMessage = "Field {0} lenght between {2} and {1} caracters.", MinimumLength = 2)]
        public string Surname { get; set; }

        [DisplayName("Passport")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(50, ErrorMessage = "Field {0} lenght between {2} and {1} caracters.", MinimumLength = 2)]
        public string Passport { get; set; }

        [NotMapped]
        [DisplayName("Passport Image")]
        public IFormFile PassportUpload { get; set; }
        public string PassportImage { get; set; }

        [DisplayName("Country")]
        [Required(ErrorMessage = "Field {0} is required")]
        public string Country { get; set; }

        [DisplayName("Native Language")]
        [Required(ErrorMessage = "Field {0} is required")]
        public string NativeLanguage { get; set; }

        [DisplayName("Session")]
        [Required(ErrorMessage = "Field {0} is required")]
        public SessionType Session { get; set; }

        [DisplayName("Duration (Weeks)")]
        [Required(ErrorMessage = "Field {0} is required")]
        public int Duration { get; set; }

        [DisplayName("Course Type")]
        [Required(ErrorMessage = "Field {0} is required")]
        public CourseType CourseType { get; set; }

        [DisplayName("Start Date")]
        [BindProperty, DataType(DataType.Date)]
        [Required(ErrorMessage = "Field {0} is required")]
        public DateTime? StartDate { get; set; }

        //[DisplayName("Finish Date")]
        //[BindProperty, DataType(DataType.Date)]
        //[Required(ErrorMessage = "Field {0} is required")]
        //public DateTime? FinishDate { get; set; }

        [DisplayName("Arrival Date")]
        [BindProperty, DataType(DataType.Date)]
        [Required(ErrorMessage = "Field {0} is required")]
        public DateTime? ArrivalDate { get; set; }

        [DisplayName("DOB")]
        [BindProperty, DataType(DataType.Date)]
        [Required(ErrorMessage = "Field {0} is required")]
        public DateTime? Dob { get; set; }

        [DisplayName("Accommodation")]
        [Required(ErrorMessage = "Field {0} is required")]
        public AccommodationType Accommodation { get; set; }
        
        [DisplayName("Accommodation Duration (Weeks)")]
        [Required(ErrorMessage = "Field {0} is required")]
        public int AccommodationDuration { get; set; }

        [DisplayName("Active?")]
        public bool Active { get; set; }

        public AgencyViewModel Agency { get; set; }
        public IEnumerable<AgencyViewModel> Agencies { get; set; }
        public Dictionary<string, string> Countries { get; set; }
        public Dictionary<string, string> Languages { get; set; }
        public IEnumerable<DocumentViewModel> Documents { get; set; }
    }
}
