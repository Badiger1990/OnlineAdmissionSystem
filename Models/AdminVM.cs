using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace OnlineAdmissionSystem.Models
{
    public class AdminVM
    {
        public AdminVM()
        {

        }
        public int Dept_ID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Department Name")]
        public string Dept_Name { get; set; }

        [DisplayName("Department Head")]
        public string Dept_Head { get; set; }

        public int Course_ID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Course_Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Course_Duration { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Course_substream { get; set; }
        public string StatusMessage { get; set; }
    }
}