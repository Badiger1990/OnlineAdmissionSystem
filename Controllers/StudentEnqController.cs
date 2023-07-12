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
            SmartAdmissionSystemDataEntities db = new SmartAdmissionSystemDataEntities();
            var departments = db.tbl_department.Where(x => x.Dept_Name != null && x.Dept_head != null).ToList();
            if (departments != null)
            {
                ViewBag.departments = departments.Select(x => new SelectListItem()
                {
                    Value = x.Dept_ID.ToString(),
                    Text = x.Dept_Name.ToString()
                });

                var courses = db.tbl_courses.Where(c=>c.Course_Name != null && c.Course_substream!=null).ToList();
                ViewBag.courses = courses.Select(x=> new SelectListItem()
                {
                    Text = x.Course_Name.ToString(),
                    Value=x.Course_Name.ToString()
                });
            }
            return View();
        }

        [HttpPost]
        public ActionResult SendEnquiry(DepartmentDataVM dataVM, FormCollection form)
        {
            string selectedValue = dataVM.SelectedDepartment;
            string strDDLValue = form["dlDeptName"].ToString();

            return View();
        }

        public JsonResult GetDepartmentByID(int id)
        {
            DepartmentDataVM departmentDataVM = new DepartmentDataVM();
            using (SmartAdmissionSystemDataEntities db=new SmartAdmissionSystemDataEntities())
            {
                var courses = db.tbl_courses.Where
                    (c => c.Dept_ID == id && c.Course_Name != null).ToList();
                if (courses!=null)
                {
                    ViewBag.courses = courses.Select(x => new SelectListItem()
                    {
                        Value = x.Course_ID.ToString(),
                        Text = x.Course_Name.ToString()
                    });
                }
            }
            return Json(ViewBag.courses);
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