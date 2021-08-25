using System;
using System.Collections.Generic;
using System.Text;

namespace RightWord.Business.Models
{
    public class Agency : Entity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Active { get; set; }


        //EF Relations
        public IEnumerable<Student> Students { get; set; }
    }
}
