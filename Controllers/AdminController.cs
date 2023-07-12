using OnlineAdmissionSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAdmissionSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminView()
        {
            using (SmartAdmissionSystemDataEntities db = new SmartAdmissionSystemDataEntities())
            {
                List<AdminVM> listAdminVMs=new List<AdminVM>();
                //var data= db.tbl_department.ToList();
                var data = (from d in db.tbl_department
                            join c in db.tbl_courses on d.Dept_ID equals c.Dept_ID
                            select new {d.Dept_ID,d.Dept_Name,d.Dept_head,
                                c.Course_Name,c.Course_ID,c.Course_duration,c.Course_substream,c.Course_Fees}).ToList();

                foreach (var item in data)
                {
                    AdminVM adminVM = new AdminVM();

                    adminVM.Dept_ID = item.Dept_ID;
                    adminVM.Dept_Head = item.Dept_head;
                    adminVM.Dept_Name = item.Dept_Name;
                    adminVM.Course_Name = item.Course_Name;
                    adminVM.Course_Duration = item.Course_duration.ToString();
                    adminVM.Course_substream = item.Course_substream;
                    adminVM.Course_ID = item.Course_ID;
                    if (item.Course_Fees != null)
                    {
                        adminVM.Course_fees = (double)item.Course_Fees;
                    }
                    listAdminVMs.Add(adminVM);
                    
                }
                return View(listAdminVMs.ToList());
            }
        }

        [HttpPost]
        public JsonResult SaveDepartmentCourse(string departmentName,string departmentHead,string courseName,string courseDuration,
            string courseSubstream,string courseFees)
        {
            tbl_department department = new tbl_department();
            using (SmartAdmissionSystemDataEntities entities = new SmartAdmissionSystemDataEntities())
            {
                tbl_courses courses = new tbl_courses();
                
                courses.Course_Name = courseName;
                courses.Course_duration = (int?)Convert.ToInt64(courseDuration);
                courses.Course_substream = courseSubstream;
                courses.Course_Fees = Convert.ToDouble(courseFees);
                department.Dept_Name = departmentName;
                department.Dept_head = departmentHead;
                department.tbl_courses.Add(courses);
                entities.tbl_department.Add(department);
                entities.SaveChanges();
            }

            return Json(department);
        }

        [HttpPost]
        public ActionResult EditDepartmentCourse()
        {

            return View();
        }
    }
}