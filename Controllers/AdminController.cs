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
                    //adminVM.Course_fees = (double)item.Course_Fees?? 0.0 :(double)item.Course_Fees;
                    listAdminVMs.Add(adminVM);
                    //listAdminVMs.AddRange(data);
                    //foreach (var course in item.tbl_courses)
                    //{
                    //    adminVM.Course_ID = course.Course_ID;
                    //    adminVM.Course_Name = course.Course_Name;
                    //    adminVM.Course_Duration = course.Course_duration.ToString();
                    //    adminVM.Course_substream = course.Course_substream;
                    //    adminVMs.Add(adminVM);

                    //}
                }
                //adminVMs.AddRange((IEnumerable<AdminVM>)data);
                return View(listAdminVMs.ToList());
            }
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