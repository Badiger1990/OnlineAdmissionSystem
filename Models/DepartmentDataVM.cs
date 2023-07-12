using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAdmissionSystem.Models
{
    public class DepartmentDataVM
    {
        public DepartmentDataVM()
        {

        }

        public int DeptID { get; set; }
        public string DeptName { get; set; }
        public string DeptHead { get; set; }

        public string CourseName { get; set; }

        public string CourseDuration { get; set; }

        public string CourseSubstream { get; set; }

        public string CourseFees { get; set; }

        public string SelectedDepartment { get; set; }
        public List<SelectListItem> DeptList{ get; set; }
    }

}