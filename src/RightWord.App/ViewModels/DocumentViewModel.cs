using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RightWord.App.ViewModels
{
    public class DocumentViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(200, ErrorMessage = "Field {0} lenght between {2} and {1} caracters.", MinimumLength = 2)]
        public string Description { get; set; }

        [DisplayName("Document Type")]
        [Required(ErrorMessage = "Field {0} is required")]
        public string DocumentType { get; set; }

        [NotMapped]
        [DisplayName("Passport Image")]
        public IFormFile ImageUpload { get; set; }
        public string Image { get; set; }
        
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Active?")]
        public bool Active { get; set; }

        [HiddenInput]
        public Guid StudentId { get; set; }
    }
}
