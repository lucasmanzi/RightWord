using System;
using System.Collections.Generic;
using System.Text;

namespace RightWord.Business.Models
{
    public class Document : Entity
    {
        public Guid StudentId { get; set; }

        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Active { get; set; }

        //EF Relations
        public Student Student { get; set; }
    }
}
