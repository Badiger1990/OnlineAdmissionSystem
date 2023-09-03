using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineAdmissionSystem.Models
{
    public class AdmissionTransactionModel
    {
        public int Admission_ID { get; set; }
        public int Course_ID { get; set; }
        public string Course_Name { get; set; }
        public Nullable<double> Degreee_marks { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public Nullable<double> Puc_marks { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public Nullable<double> Sslc_marks { get; set; }
        public string Document_path { get; set; }
        [Required(ErrorMessage ="This field is required")]

        public string Student_name { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public string Student_father_name { get; set; }
        public Nullable<System.DateTime> Student_dob { get; set; }
        [Required(ErrorMessage ="This field is required")]

        public string Student_gender { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public string Student_address { get; set; }
        public string Admission_status { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(maximumLength:12,ErrorMessage ="Enter valid ADHAR Number",MinimumLength =12)]
        public string Adhar_number { get; set; }

        [Required(ErrorMessage = "This field is required")]

        public string Student_religion { get; set; }
        public Nullable<int> UserID { get; set; }

        public virtual tbl_courses tbl_courses { get; set; }
        public virtual UserMaster UserMaster { get; set; }

        public string InforMessage { get; set; }
    }
}