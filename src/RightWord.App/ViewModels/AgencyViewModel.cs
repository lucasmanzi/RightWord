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

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Active?")]
        public bool Active { get; set; }

        [NotMapped]
        public IEnumerable<StudentViewModel> Students { get; set; }
    }
}
