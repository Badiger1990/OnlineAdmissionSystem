using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAdmissionSystem.Models;

namespace OnlineAdmissionSystem.Controllers
{
    public class ApproveAdmissionController : Controller
    {
        // GET: ApproveAdmission
        public ActionResult ApproveAdmissions()
        {
            List<AdmissionTransactionModel> admissionTransactionsList = new List<AdmissionTransactionModel>();

            using (SmartAdmissionSystemDataEntities entites=new SmartAdmissionSystemDataEntities())
            {
                var result = (from admissions in entites.tbl_AdmissionTransactions
                              join course in entites.tbl_courses on admissions.course_ID equals course.Course_ID                             
                             select new {admissions,course}).ToList();

                foreach (var item in result)
                {
                    AdmissionTransactionModel admissionTransaction = new AdmissionTransactionModel();
                    admissionTransaction.Admission_ID = item.admissions.admission_ID;
                    admissionTransaction.Course_ID = item.course.Course_ID;
                    admissionTransaction.Student_name = item.admissions.student_name;
                    admissionTransaction.Student_father_name= item.admissions.student_father_name;
                    admissionTransaction.Student_dob= item.admissions.student_dob;
                    admissionTransaction.Student_gender= item.admissions.student_gender;
                    admissionTransaction.Student_religion= item.admissions.student_religion;
                    admissionTransaction.Student_address= item.admissions.student_address;
                    if (item.course.Course_Name != null)
                    {
                        admissionTransaction.Course_Name = item.course.Course_Name ?? "Nothing";

                    }
                    admissionTransaction.Admission_status= item.admissions.admission_status;
                    admissionTransactionsList.Add(admissionTransaction);
                }
            }
            return View(admissionTransactionsList.ToList());
        }

        [HttpPost]
        public ActionResult Approve(int admissionId)
        {
            using (SmartAdmissionSystemDataEntities entites = new SmartAdmissionSystemDataEntities())
            {
                var rejectStudent = entites.tbl_AdmissionTransactions.Where(d => d.admission_ID == admissionId).FirstOrDefault();
                if (rejectStudent != null)
                {
                    rejectStudent.admission_status = "Approved";
                    entites.SaveChanges();
                }
            }
            return View();

        }

        [HttpPost]
        public ActionResult Reject(int admissionId)
        {
            using (SmartAdmissionSystemDataEntities entites = new SmartAdmissionSystemDataEntities())
            {
                var rejectStudent = entites.tbl_AdmissionTransactions.Where(d => d.admission_ID == admissionId).FirstOrDefault();
                if (rejectStudent != null)
                {
                    rejectStudent.admission_status = "Rejected";
                    entites.SaveChanges();
                }
            }
            return View();

        }
    }
}