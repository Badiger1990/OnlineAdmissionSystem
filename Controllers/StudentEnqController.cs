using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAdmissionSystem.Models;

namespace OnlineAdmissionSystem.Controllers
{
    public class StudentEnqController : Controller
    {
        // GET: StudentEnq
        public ActionResult Enquiry()
        {
            List<DepartmentDataVM> list = PopulateData();

            return View(new SelectList(list,"Department Name","Department Head"));
        }

        [HttpPost]
        public ActionResult SendEnquiry()
        {
            return View();
        }

        private static List<DepartmentDataVM> PopulateData()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            List<DepartmentDataVM> departmentDataVM1 = new List<DepartmentDataVM>();
            using (SmartAdmissionSystemDataEntities db = new SmartAdmissionSystemDataEntities())
            {

                foreach (var dept in db.tbl_department.ToList())
                {
                    departmentDataVM1.Add(new DepartmentDataVM
                    {
                        DeptName = dept.Dept_Name,
                        DeptHead=dept.Dept_head
                    });
                }

            }
            return departmentDataVM1;
        }
    }
}