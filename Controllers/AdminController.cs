using OnlineAdmissionSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
            tbl_courses courses = new tbl_courses();
            AdminVM adminVM = new AdminVM();

            using (SmartAdmissionSystemDataEntities entities = new SmartAdmissionSystemDataEntities())
            {
                
                courses.Course_Name = courseName;
                courses.Course_duration = (int?)Convert.ToInt64(courseDuration);
                courses.Course_substream = courseSubstream;
                courses.Course_Fees = Convert.ToDouble(courseFees);
                department.Dept_Name = departmentName;
                department.Dept_head = departmentHead;
                adminVM.StatusMessage = "Added sucessfully!";
                department.tbl_courses.Add(courses);
                entities.tbl_department.Add(department);
                entities.SaveChanges();
            }
            return Json(department);
        }

        [HttpPost]
        public ActionResult UpdateDepartmentCourse(string departmentID, string departmentName, string departmentHead, string courseName, string courseDuration,
            string courseSubstream, string courseFees)
        {
            tbl_department department = new tbl_department();
            tbl_courses courses = new tbl_courses();
            int deptID= Convert.ToInt32(departmentID);

            using (SmartAdmissionSystemDataEntities entities = new SmartAdmissionSystemDataEntities())
            {
                var queryResult = (from course in entities.tbl_courses
                                   join tbldept in entities.tbl_department on course.Dept_ID equals tbldept.Dept_ID
                                   where course.Dept_ID == deptID
                                   select new
                                   {
                                       tbldept,course
                                   }
                                   ).FirstOrDefault();
                                 
               // var dept = entities.tbl_department.SingleOrDefault(d => d.Dept_ID == Convert.ToInt32(departmentID));
                if (queryResult != null)
                {
                    queryResult.tbldept.Dept_Name = departmentName;
                    queryResult.tbldept.Dept_head = departmentHead;
                    queryResult.course.Course_Name = courseName;
                    queryResult.course.Course_duration = Convert.ToInt32(courseDuration);
                    queryResult.course.Course_substream = courseSubstream;
                    queryResult.course.Course_Fees = Convert.ToDouble(courseFees);
                    entities.SaveChanges();
                }
            }
                return View();
        }

        [HttpPost]
        public ActionResult DeleteCourse(int courseId)
        {
            int Course_ID = Convert.ToInt32(courseId);

            using (SmartAdmissionSystemDataEntities entities = new SmartAdmissionSystemDataEntities())
            {
                tbl_courses result = (from course in entities.tbl_courses
                              where course.Course_ID == Course_ID
                              select course).FirstOrDefault();

                entities.tbl_courses.Remove(result);
                entities.SaveChanges();
            }
            return new EmptyResult();
        }
    }
}