using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAdmissionSystem.Models;

namespace OnlineAdmissionSystem.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorise(UserMaster userMaster)
        {
            using (SmartAdmissionSystemDataEntities db=new SmartAdmissionSystemDataEntities())
            {
                var userDetails= db.UserMasters.Where(u=>u.UserName==userMaster.UserName && u.Password==userMaster.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userMaster.LoginErrorMessage = "Wrong Username or Password";
                    return View("SignIn", userMaster);
                }
                else
                {
                    if (userDetails.UserType == null)
                    {
                        userMaster.LoginErrorMessage = "Invalid User";
                        return View("SignIn", userMaster);
                    }

                    Session["UserID"] = userMaster.UserID;
                    if (userDetails.UserType.Equals("Admin"))
                    {
                        return RedirectToAction("AdminView", "Admin");
                    }
                    else if(userDetails.UserType.Equals("Student"))
                    {
                        return RedirectToAction("Enquiry", "StudentEnq");
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}