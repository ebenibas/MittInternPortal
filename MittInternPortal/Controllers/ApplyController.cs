using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MittInternPortal.Models;

namespace MittInternPortal.Controllers
{
    public class ApplyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Apply
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ApplyJobs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ApplyJobs(Models.Apply sm, HttpPostedFileBase file /*Resume r*/)
        {
            ViewBag.FullName = sm.FullName;
            ViewBag.Email = sm.Email;
            ViewBag.EmployerId = sm.Employer.CompanyName;

            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedResume"), _FileName);
                    file.SaveAs(_path);
                    //r.Name = _FileName;
                    //db.Resume.Add(r);
                    //db.SaveChanges();

                }
                ViewBag.Message = "File Uploded Successfully!";
                return View("JobApplied");
            }
            catch
            {
                ViewBag.Message = "File Upload failed!";
                return View();
            }

        }


        public ActionResult ApplyJob()
        {
            return View();
        }
        public ActionResult SubmitResume()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SubmitResume(HttpPostedFileBase file /*Resume r*/)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedResume"), _FileName);
                    file.SaveAs(_path);
                    //r.Name = _FileName;
                    //db.Resume.Add(r);
                    //db.SaveChanges();

                }
                ViewBag.Message = "File Uploded Successfully!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File Upload failed!";
                return View();
            }
        }

        public ActionResult JobApplied()
        {
            return View();
        }


    }
}