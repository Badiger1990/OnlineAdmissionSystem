using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAdmissionSystem.Models;
using OnlineAdmissionSystem.Utilities;

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
        public ActionResult Authorise(SignInModels userMaster)
        {
            try
            {
                using (SmartAdmissionSystemDataEntities db = new SmartAdmissionSystemDataEntities())
                {
                    var userDetails = db.UserMasters.Where(u => u.UserName == userMaster.UserName && u.Password == userMaster.Password).FirstOrDefault();
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
                            Log.Warn("Invalid user trying to login");
                            return View("SignIn", userMaster);
                        }

                        Session["UserID"] = userDetails.UserID;
                        if (userDetails.UserType.Equals("Admin"))
                        {
                            Log.Info(userDetails.UserName + " Logged in sucessfully..");
                            return RedirectToAction("AdminView", "Admin");
                        }
                        else if (userDetails.UserType.ToLower().Equals("student"))
                        {
                            Log.Info(userDetails.UserName + " Logged in sucessfully..");
                            return RedirectToAction("Enquiry", "StudentEnq");
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}