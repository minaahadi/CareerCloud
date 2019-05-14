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
    public class CompanyProfilesController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyProfiles
        public ActionResult Index()
        {
            var companyProfiles = db.CompanyProfiles.Include(a => a.CompanyDescriptions).Include(a => a.CompanyJobs).ToList();
            List<CompanyProfileVM> cpvm = new List<CompanyProfileVM>();
            foreach (var companyProfile in companyProfiles)
            {
                cpvm.Add(new CompanyProfileVM
                {
                    Id = companyProfile.Id,
                    CompanyName = companyProfile.CompanyDescriptions.FirstOrDefault(cd => cd.Company == companyProfile.Id)?.CompanyName,
                    CompanyWebsite = companyProfile.CompanyWebsite,
                    ContactPhone = companyProfile.ContactPhone,
                    ContactName = companyProfile.ContactName


                });
            }

            return View(cpvm);
        }

        // GET: CompanyProfiles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfilePoco companyProfilePoco = db.CompanyProfiles.Include(cp => cp.CompanyDescriptions).SingleOrDefault(cp => cp.Id==id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            CompanyProfileVM companyProfileVM = new CompanyProfileVM
            {
                Id = companyProfilePoco.Id,
                CompanyName = companyProfilePoco.CompanyDescriptions.FirstOrDefault(cd => cd.Company == id).CompanyName,
                CompanyWebsite = companyProfilePoco.CompanyWebsite,
                ContactPhone = companyProfilePoco.ContactPhone,
                ContactName = companyProfilePoco.ContactName
            };
            return View(companyProfileVM);
        }

        // GET: CompanyProfiles/Create
        public ActionResult Create()
        {
            CompanyProfileVM cpvm = new CompanyProfileVM();
            return View(cpvm);
        }

        // POST: CompanyProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo")] CompanyProfilePoco companyProfilePoco, [Bind(Include = "Id,Company,LanguageId,CompanyName,CompanyDescription")] CompanyDescriptionPoco companyDescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                companyProfilePoco.Id = Guid.NewGuid();
                companyDescriptionPoco.Id = Guid.NewGuid();
                companyDescriptionPoco.Company = companyProfilePoco.Id;
                //companyDescriptionPoco.LanguageId = db.SystemLanguageCodes.SingleOrDefault(sl => sl.LanguageID == "EN").LanguageID;
                db.CompanyProfiles.Add(companyProfilePoco);
                db.CompanyDescriptions.Add(companyDescriptionPoco);
                db.SaveChanges();
                return RedirectToAction("Details",new { id= companyProfilePoco.Id});
            }

            return View(companyProfilePoco);
        }

        // GET: CompanyProfiles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfilePoco companyProfilePoco = db.CompanyProfiles.Find(id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // POST: CompanyProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo")] CompanyProfilePoco companyProfilePoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyProfilePoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyProfilePoco);
        }

        // GET: CompanyProfiles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfilePoco companyProfilePoco = db.CompanyProfiles.Find(id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // POST: CompanyProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyProfilePoco companyProfilePoco = db.CompanyProfiles.Find(id);
            db.CompanyProfiles.Remove(companyProfilePoco);
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
