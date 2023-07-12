using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OnlineAdmissionSystem.Models
{
    public class SignInModels
    {
        public int UserID { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string Email_ID { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Phone_Number { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}