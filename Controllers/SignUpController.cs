using OnlineAdmissionSystem.Models;
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
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserMaster userMaster)
        {
            if (ModelState.IsValid)
            {
                SmartAdmissionSystemDataEntities db = new SmartAdmissionSystemDataEntities();
                userMaster.UserType = "student";
                db.UserMasters.Add(userMaster);
                db.SaveChanges();
            }
            return View(userMaster);
        }
    }
}