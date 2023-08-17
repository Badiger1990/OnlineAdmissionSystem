using OnlineAdmissionSystem.Models;
using OnlineAdmissionSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAdmissionSystem.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult SignUp()
        {
            return View(new RegistrationModel());
        }

        [HttpPost]
        public ActionResult SignUp(RegistrationModel data)
        {
            UserMaster userMaster = new UserMaster();

            //if (ModelState.IsValid)
            //{
                SmartAdmissionSystemDataEntities db = new SmartAdmissionSystemDataEntities();
                userMaster.UserType = "Student";
                userMaster.UserName = data.UserName;
                userMaster.Email_ID=data.Email_ID;
                userMaster.Phone_Number = data.Phone_Number;
                userMaster.Gender = data.Gender;
                db.UserMasters.Add(userMaster);
                db.SaveChanges();
            data.InfoMessage = "Registration sucessfull!";
            Log.Info(data.UserName + " Has been registred sucessfully..");
            //}
            return View(data);
        }
    }
}