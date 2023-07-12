using OnlineAdmissionSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAdmissionSystem.Controllers
{
    public class AdmissionRequestController : Controller
    {
        // GET: AdmissionRequest
        public ActionResult Index()
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

                var courses = db.tbl_courses.Where(c => c.Course_Name != null && c.Course_substream != null).ToList();
                ViewBag.courses = courses.Select(x => new SelectListItem()
                {
                    Text = x.Course_Name.ToString(),
                    Value = x.Course_ID.ToString()
                });
            }
            return View();
        }
    }
}