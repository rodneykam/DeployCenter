using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeployCenter.Models
{
    public class UserModel
    {
        [DisplayName("User Name")]
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}
