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
            return View();
        }

        public ActionResult SaveDepartment(AdminVM adminVM)
        {
            using (SmartAdmissionSystemDataEntities db=new SmartAdmissionSystemDataEntities())
            {
                tbl_department dept = new tbl_department();
                dept.Dept_Name = adminVM.Dept_Name;
                dept.Dept_head = adminVM.Dept_Head;
                db.tbl_department.Add(dept);
                db.SaveChanges();
                int deptID = dept.Dept_ID;
                tbl_courses course = new tbl_courses();
                course.Dept_ID = deptID;
                course.Course_Name = adminVM.Course_Name;
                course.Course_duration = Convert.ToInt32(adminVM.Course_Duration);
                course.Course_substream = adminVM.Course_substream;
                db.tbl_courses.Add(course);
                db.SaveChanges();
                adminVM.StatusMessage = "Details saved Successfully!";
            }
            
            //return Content("Details Saved Successfully!");
            //return RedirectToAction("AdminView", adminVM);
            return View("AdminView");
        }
    }
}