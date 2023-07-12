using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineAdmissionSystem.Models
{
    public class RegistrationModel
    {
        public int UserID { get; set; }

        [DisplayName("User Name")]
        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }

        [NotMapped]
        public string ConfirmPassword { get; set; }
        public string UserType { get; set; }
        public string Email_ID { get; set; }
        public string Gender { get; set; }
        
        public Nullable<int> Phone_Number { get; set; }
    }
}