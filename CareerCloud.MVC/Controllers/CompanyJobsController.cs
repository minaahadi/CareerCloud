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
    public class CompanyJobsController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyJobs
        public ActionResult Index()
        {
            return View();
        }

        // GET: CompanyJobs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobPoco companyJobPoco = db.CompanyJobs.Find(id);
            if (companyJobPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobPoco);
        }
        public ActionResult PostedJob(Guid id)
        {
            var companyJobs = db.CompanyJobs.Include(c => c.CompanyJobDescriptions).Where(cj =>cj.Company == id).ToList();
           // var companyJobs = db.CompanyProfiles.Include(cp => cp.CompanyJobs).Where(cp => cp.Id == id).ToList();
            ViewBag.CompanyName = db.CompanyProfiles.Include(Cp => Cp.CompanyDescriptions)
                .SingleOrDefault(cp => cp.Id == id).CompanyDescriptions.Where(cd => cd.Company == id)
                .FirstOrDefault()?.CompanyName;
            TempData["CompanyId"] = id;
            List<JobPostedVM> jobPostedVMs = new List<JobPostedVM>();
            if (companyJobs == null)
            {
                return View(jobPostedVMs);
            }
           
            foreach (var companyJob in companyJobs)
            {
                jobPostedVMs.Add(
                    new JobPostedVM
                    {
                        JobId = companyJob.Id,
                        JobTitle = companyJob.CompanyJobDescriptions.FirstOrDefault().JobName,
                        JobDescription = companyJob.CompanyJobDescriptions.FirstOrDefault().JobDescriptions,
                        JobCreated =companyJob.ProfileCreated
                    });

            }

            return View(jobPostedVMs);
        }
        // GET: CompanyJobs/Create
        public ActionResult Create(Guid id)
        {
           // var companyJob = db.CompanyJobs.Include(cp => cp.CompanyJobDescriptions).Where(cp=>cp.Company == id).FirstOrDefault();
            //ViewBag.Company = new SelectList(db.CompanyProfiles, "Id", "CompanyWebsite");
            TempData["CompanyId"] = id;
            TempData.Keep();
            var createJobVM = new CreateJobVM();
            createJobVM.ProfileCreated = DateTime.Now;
            return View(createJobVM);
        }

        // POST: CompanyJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Company,ProfileCreated,IsInactive,IsCompanyHidden")] CompanyJobPoco companyJobPoco, [Bind(Include = "Id,Job,JobName,JobDescriptions")]CompanyJobDescriptionPoco companyJobDescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                
                    companyJobPoco.Id = Guid.NewGuid();
                    companyJobPoco.Company = (Guid)TempData["CompanyId"];
                    companyJobDescriptionPoco.Id = Guid.NewGuid();
                    companyJobDescriptionPoco.Job = companyJobPoco.Id;
                    TempData["CompanyId"] = companyJobPoco.Company;
                TempData.Keep();

                db.CompanyJobs.Add(companyJobPoco);
                db.CompanyJobDescription.Add(companyJobDescriptionPoco);
                db.SaveChanges();
                return RedirectToAction("Create",new { Controller= "CompanyJobEducations",job= companyJobPoco.Id });
            }

            ViewBag.Company = new SelectList(db.CompanyProfiles, "Id", "CompanyWebsite", companyJobPoco.Company);
            return View(companyJobPoco);
        }

        // GET: CompanyJobs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobPoco companyJobPoco = db.CompanyJobs.Find(id);
            if (companyJobPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company = new SelectList(db.CompanyProfiles, "Id", "CompanyWebsite", companyJobPoco.Company);
            return View(companyJobPoco);
        }

        // POST: CompanyJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Company,ProfileCreated,IsInactive,IsCompanyHidden")] CompanyJobPoco companyJobPoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyJobPoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.CompanyProfiles, "Id", "CompanyWebsite", companyJobPoco.Company);
            return View(companyJobPoco);
        }

        // GET: CompanyJobs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobPoco companyJobPoco = db.CompanyJobs.Find(id);
            if (companyJobPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobPoco);
        }

        // POST: CompanyJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyJobPoco companyJobPoco = db.CompanyJobs.Find(id);
            db.CompanyJobs.Remove(companyJobPoco);
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
