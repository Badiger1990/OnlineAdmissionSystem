using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAdmissionSystem.Models
{
    public class AdmissionTransactionModel
    {
        public int Admission_ID { get; set; }
        public Nullable<int> Course_ID { get; set; }
        public Nullable<double> Degreee_marks { get; set; }
        public Nullable<double> Puc_marks { get; set; }
        public Nullable<double> Sslc_marks { get; set; }
        public string Document_path { get; set; }
        public string Student_name { get; set; }
        public string Student_father_name { get; set; }
        public Nullable<System.DateTime> Student_dob { get; set; }
        public string Student_gender { get; set; }
        public string Student_address { get; set; }
        public string Admission_status { get; set; }
        public Nullable<int> Adhar_number { get; set; }
        public string Student_religion { get; set; }
        public Nullable<int> UserID { get; set; }

        public virtual tbl_courses tbl_courses { get; set; }
        public virtual UserMaster UserMaster { get; set; }
    }
}