using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTestApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Enter User Id")]
        [DisplayName("User Id")]
        public string UserId { get; set; }

        [Required(ErrorMessage ="Enter Password")]
        [DisplayName("Password")]
        public string UserPassword { get; set; }
    }
}