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
    public class CompanyJobSkillsController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyJobSkills
        public ActionResult Index()
        {
            var companyJobSkills = db.CompanyJobSkills.Include(c => c.CompanyJob);
            return View(companyJobSkills.ToList());
        }

        // GET: CompanyJobSkills/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobSkillPoco companyJobSkillPoco = db.CompanyJobSkills.Find(id);
            if (companyJobSkillPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobSkillPoco);
        }

        // GET: CompanyJobSkills/Create
        public ActionResult Create(Guid job)
        {
            TempData["job"] = job;
            ViewBag.Job = new SelectList(db.CompanyJobs, "Id", "Id");
            TempData.Keep();
            return View();
        }

        // POST: CompanyJobSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Job,Skill,SkillLevel,Importance")] CompanyJobSkillPoco companyJobSkillPoco)
        {
            if (ModelState.IsValid)
            {
                companyJobSkillPoco.Id = Guid.NewGuid();
                companyJobSkillPoco.Job = (Guid)TempData["job"];
                db.CompanyJobSkills.Add(companyJobSkillPoco);
                db.SaveChanges();
                Guid appid = (Guid)TempData["CompanyId"];

                return RedirectToAction("PostedJob", new {Controller= "CompanyJobs", id= appid });
            }

            ViewBag.Job = new SelectList(db.CompanyJobs, "Id", "Id", companyJobSkillPoco.Job);
            return View(companyJobSkillPoco);
        }

        // GET: CompanyJobSkills/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobSkillPoco companyJobSkillPoco = db.CompanyJobSkills.Find(id);
            if (companyJobSkillPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Job = new SelectList(db.CompanyJobs, "Id", "Id", companyJobSkillPoco.Job);
            return View(companyJobSkillPoco);
        }

        // POST: CompanyJobSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Job,Skill,SkillLevel,Importance")] CompanyJobSkillPoco companyJobSkillPoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyJobSkillPoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Job = new SelectList(db.CompanyJobs, "Id", "Id", companyJobSkillPoco.Job);
            return View(companyJobSkillPoco);
        }

        // GET: CompanyJobSkills/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobSkillPoco companyJobSkillPoco = db.CompanyJobSkills.Find(id);
            if (companyJobSkillPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobSkillPoco);
        }

        // POST: CompanyJobSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyJobSkillPoco companyJobSkillPoco = db.CompanyJobSkills.Find(id);
            db.CompanyJobSkills.Remove(companyJobSkillPoco);
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
