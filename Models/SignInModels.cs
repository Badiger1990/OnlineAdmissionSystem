using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineAdmissionSystem.Models
{
    public class SignInModels
    {
        public int UserID { get; set; }
        
        [Required(ErrorMessage ="This field is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
        public string UserType { get; set; }
        public string Email_ID { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Phone_Number { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}