using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.MVC.Models;
using CareerCloud.Pocos;

namespace CareerCloud.MVC.Controllers
{
    public class ApplicantProfilesController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: ApplicantProfiles
        public ActionResult Index()
        {
            var applicantProfiles = db.ApplicantProfiles.Include(a => a.SecurityLogin).Include(a => a.SystemCountryCode).ToList();
            List<ApplicantProfileVM> apvm = new List<ApplicantProfileVM>();
            foreach (var applicantProfile in applicantProfiles)
            {
                apvm.Add(new ApplicantProfileVM
                {
                    Id = applicantProfile.Id,
                    FullName = applicantProfile.SecurityLogin.FullName,
                    Email = applicantProfile.SecurityLogin.EmailAddress,
                    PhoneNumber = applicantProfile.SecurityLogin.PhoneNumber,
                    CompanyName = applicantProfile.ApplicantWorkHistory.Where(ap => ap.Applicant == applicantProfile.Id).FirstOrDefault()?.CompanyName,
                    Country = applicantProfile.SystemCountryCode.Name,
                    Province = applicantProfile.Province,
                    City = applicantProfile.City

                });
            }
            
            return View(apvm);
        }

        // GET: ApplicantProfiles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantProfilePoco applicantProfilePoco = db.ApplicantProfiles.Find(id);
         
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantProfilePoco);
        }

        // GET: ApplicantProfiles/Create
         public ActionResult Create(Guid LoginId)
        {
            //ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "Login");
            TempData["Login"] = LoginId;
            TempData.Keep();
            ViewBag.Country = new SelectList(db.SystemCountryCodes, "Code", "Name");
            return View();
        }

        // POST: ApplicantProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,CurrentSalary,CurrentRate,Currency,Country,Province,Street,City,PostalCode")] ApplicantProfilePoco applicantProfilePoco)
        {
            if (ModelState.IsValid)
            {
                applicantProfilePoco.Id = Guid.NewGuid();
                applicantProfilePoco.Login = (Guid)TempData["Login"];
                db.ApplicantProfiles.Add(applicantProfilePoco);
                db.SaveChanges();
                TempData["ApplicantId"] = applicantProfilePoco.Id;
                TempData.Keep();
                return RedirectToAction("Details",new { id= applicantProfilePoco.Id });
            }

            //ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "Login", applicantProfilePoco.Login);
            ViewBag.Country = new SelectList(db.SystemCountryCodes, "Code", "Name", applicantProfilePoco.Country);
            return View(applicantProfilePoco);
        }

        // GET: ApplicantProfiles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantProfilePoco applicantProfilePoco = db.ApplicantProfiles.Find(id);
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "Login", applicantProfilePoco.Login);
            ViewBag.Country = new SelectList(db.SystemCountryCodes, "Code", "Name", applicantProfilePoco.Country);
            return View(applicantProfilePoco);
        }

        // POST: ApplicantProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,CurrentSalary,CurrentRate,Currency,Country,Province,Street,City,PostalCode")] ApplicantProfilePoco applicantProfilePoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicantProfilePoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "Login", applicantProfilePoco.Login);
            ViewBag.Country = new SelectList(db.SystemCountryCodes, "Code", "Name", applicantProfilePoco.Country);
            return View(applicantProfilePoco);
        }

        // GET: ApplicantProfiles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantProfilePoco applicantProfilePoco = db.ApplicantProfiles.Find(id);
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantProfilePoco);
        }

        // POST: ApplicantProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantProfilePoco applicantProfilePoco = db.ApplicantProfiles.Find(id);
            db.ApplicantProfiles.Remove(applicantProfilePoco);
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
