using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.MVC.Controllers
{
    public class CompanyJobEducationsController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyJobEducations
        public ActionResult Index()
        {
            var companyJobEducation = db.CompanyJobEducation.Include(c => c.CompanyJob);
            return View(companyJobEducation.ToList());
        }

        // GET: CompanyJobEducations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobEducationPoco companyJobEducationPoco = db.CompanyJobEducation.Find(id);
            if (companyJobEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobEducationPoco);
        }

        // GET: CompanyJobEducations/Create
        public ActionResult Create(Guid job)
        {
            TempData["job"] = job;
            ViewBag.Job = new SelectList(db.CompanyJobs, "Id", "Id");
            TempData.Keep();
            return View();
        }

        // POST: CompanyJobEducations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Job,Major,Importance")] CompanyJobEducationPoco companyJobEducationPoco)
        {
            if (ModelState.IsValid)
            {
                companyJobEducationPoco.Id = Guid.NewGuid();
                companyJobEducationPoco.Job = (Guid)TempData["job"];
                db.CompanyJobEducation.Add(companyJobEducationPoco);
                db.SaveChanges();
                TempData.Keep();
                return RedirectToAction("Create",new { Controller= "CompanyJobSkills", job= companyJobEducationPoco.Job });
            }

            ViewBag.Job = new SelectList(db.CompanyJobs, "Id", "Id", companyJobEducationPoco.Job);
            return View(companyJobEducationPoco);
        }

        // GET: CompanyJobEducations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobEducationPoco companyJobEducationPoco = db.CompanyJobEducation.Find(id);
            if (companyJobEducationPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Job = new SelectList(db.CompanyJobs, "Id", "Id", companyJobEducationPoco.Job);
            return View(companyJobEducationPoco);
        }

        // POST: CompanyJobEducations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Job,Major,Importance")] CompanyJobEducationPoco companyJobEducationPoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyJobEducationPoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Job = new SelectList(db.CompanyJobs, "Id", "Id", companyJobEducationPoco.Job);
            return View(companyJobEducationPoco);
        }

        // GET: CompanyJobEducations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobEducationPoco companyJobEducationPoco = db.CompanyJobEducation.Find(id);
            if (companyJobEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobEducationPoco);
        }

        // POST: CompanyJobEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyJobEducationPoco companyJobEducationPoco = db.CompanyJobEducation.Find(id);
            db.CompanyJobEducation.Remove(companyJobEducationPoco);
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
    }
}
