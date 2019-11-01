using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MittInternPortal.Models;

namespace MittInternPortal.Controllers
{
    public class JobPostsController : Controller
    {

        RoleManager<IdentityRole> rolesManager;
        UserManager<Models.ApplicationUser> usersManager;

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobPosts
        public ActionResult Index()
        {
            var jobPosts = db.JobPosts.Include(j => j.Round);
            return View(jobPosts.ToList());
        }

        // GET: JobPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // GET: JobPosts/Create
        public ActionResult Create()
        {
            ViewBag.EmployerId = new SelectList(db.Employer, "Id", "FullName");
            ViewBag.RoundId = new SelectList(db.Rounds, "Id", "Session");
            return View();
        }

        // POST: JobPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployerId,RoundId,CompanyAddress,Position,Posted,Description")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                db.JobPosts.Add(jobPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployerId = new SelectList(db.Employer, "Id", "FullName", jobPost.Employers.FullName);
            ViewBag.RoundId = new SelectList(db.Rounds, "Id", "Session", jobPost.RoundId);
            return View(jobPost);
        }

        // GET: JobPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployerId = new SelectList(db.Employer, "Id", "FullName", jobPost.Employers.FullName);
            ViewBag.RoundId = new SelectList(db.Rounds, "Id", "Session", jobPost.RoundId);
            return View(jobPost);
        }

        // POST: JobPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployerId,RoundId,CompanyAddress,Position,Posted,Description")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployerId = new SelectList(db.Employer, "Id", "FullName", jobPost.Employers.FullName);
            ViewBag.RoundId = new SelectList(db.Rounds, "Id", "Session", jobPost.RoundId);
            return View(jobPost);
        }

        // GET: JobPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // POST: JobPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobPost jobPost = db.JobPosts.Find(id);
            db.JobPosts.Remove(jobPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult MyJobPost()
        {
            if (User.IsInRole("Admin"))
            {
                var userId = User.Identity.GetUserId();
                db.JobPosts.Where(s => s.EmployerId == userId).ToList();
            };
            return View();
        }
        //public ActionResult ApplyToPosting(string userId, int JobPostId)
        //{
        //    var student = db.Student.Find(userId);
        //    //if user is not a student they get  back to the job post index
        //    if (student == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.StudentId = student.Id;
        //    var JobPost = db.JobPosts.Include(po => po.Employers.FullName).FirstOrDefault(x => x.Id == JobPostId);
        //    return View(JobPost);
        //    //this is the page to load up and make an email
        //}
        //[HttpPost]
        //public ActionResult ApplyToPosting(int userId, int JobPostsId, string coverLetter)
        //{

        //    var student = db.Student.FirstOrDefault(stud => stud.Id == userId);

        //    JobPost jobposting = db.JobPosts.Include(x => x.Employers).FirstOrDefault(post => post.Id == JobPostsId);

          

        //}
    }
}
