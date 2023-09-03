using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAdmissionSystem.Controllers
{
    public class UploadFilesController : Controller
    {
        // GET: UploadFiles
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase fileBase)
        {
            if (fileBase.ContentLength>0)
            {
                string path = Server.MapPath("~/UploadedDocuments/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                fileBase.SaveAs(path + Path.GetFileName(fileBase.FileName));
                ViewBag.Message = "File uploaded successfully.";
            }
            return View();
        }
    }
}