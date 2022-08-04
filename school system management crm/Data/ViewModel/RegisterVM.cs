using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace school_system_management_crm.Data.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Email Address is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        [Required(ErrorMessage = "Confrim your passowrd")]
        public string ConfrimPassword { get; set; }
    }
}
