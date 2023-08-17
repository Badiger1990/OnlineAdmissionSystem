using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAdmissionSystem.Controllers
{
    public class MakePaymentController : Controller
    {
        // GET: MakePayment
        public ActionResult PaymentWindow()
        {
            return View();
        }
    }
}