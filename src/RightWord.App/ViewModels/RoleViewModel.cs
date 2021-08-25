using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RightWord.App.ViewModels
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
            Users = new List<string>();
        }

        public Guid Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Role Name is required")]
        public string Name { get; set; }

        public List<string> Users { get; set; }
    }
}
