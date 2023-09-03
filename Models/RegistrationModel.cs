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
        [Required(ErrorMessage ="This field is required!")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmed Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password dosen't match")]
        public string ConfirmPassword { get; set; }
        public string UserType { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="This field is required")]
        public string Email_ID { get; set; }
        
        [Required(ErrorMessage ="This field is required")]
        public string Gender { get; set; }
        
        [Required(ErrorMessage ="Enter valid number")]
       // [Range(0,9, ErrorMessage ="Enter valid number")]
        //[DataType(DataType.PhoneNumber,ErrorMessage ="Only Phone number accepted")]
        //[Range(1,10,ErrorMessage ="Ten numbers required")]
        //[DataType(DataType.PhoneNumber)]
        //[Phone]
       [StringLength(10,ErrorMessage ="Enter valid phone number",MinimumLength =10)]
            //0,12, ErrorMessage = "Phone number must be between 0-9.")]
        public string Phone_Number { get; set; }

        public string InfoMessage { get; set; }
    }
}