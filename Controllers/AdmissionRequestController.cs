using OnlineAdmissionSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAdmissionSystem.EmailLogic;

namespace OnlineAdmissionSystem.Controllers
{
    public class AdmissionRequestController : Controller
    {
        // GET: AdmissionRequest
        public ActionResult Index()
        {
            var userId = Convert.ToInt32(Session["UserID"]);

            SmartAdmissionSystemDataEntities db = new SmartAdmissionSystemDataEntities();
            var admissionStatus=(from status in db.tbl_AdmissionTransactions
                                where status.UserID == userId
                                select status.admission_status).FirstOrDefault();
            ViewBag.AdmissionStatus = admissionStatus;

            var departments = db.tbl_department.Where(x => x.Dept_Name != null && x.Dept_head != null).ToList();
            if (departments != null)
            {
                ViewBag.departments = departments.Select(x => new SelectListItem()
                {
                    Value = x.Dept_ID.ToString(),
                    Text = x.Dept_Name.ToString()
                });

                var courses = db.tbl_courses.Where(c => c.Course_Name != null && c.Course_substream != null).ToList();
                ViewBag.courses = courses.Select(x => new SelectListItem()
                {
                    Text = x.Course_Name.ToString(),
                    Value = x.tbl_department.Dept_Name.ToString()
                });
            }
            return View();
        }

        [HttpPost]
        public ActionResult SaveAdmissionRequest(tbl_AdmissionTransactions data)
        {
            using (SmartAdmissionSystemDataEntities db=new SmartAdmissionSystemDataEntities())
            {
                //var course = Convert.ToInt32(Request.Form["Course_ID"].ToString());
                //data.course_ID = course;
                data.UserID = Convert.ToInt32(Session["UserID"]);
                data.admission_status = "Pending";
                db.tbl_AdmissionTransactions.Add(data);
                db.SaveChanges();
                var emailId = db.UserMasters.Where(u => u.UserID == data.UserID).FirstOrDefault();
                if (emailId != null)
                {
                    IEMailHelper eMailHelper=new EMailHelper();
                    //eMailHelper.SendEmail(emailId.ToString());
                }
            }
            return View(data);
        }
    }
}