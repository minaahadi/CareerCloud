﻿using System;
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
    public class SystemLanguageCodesController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: SystemLanguageCodes
        public ActionResult Index()
        {
            return View(db.SystemLanguageCodes.ToList());
        }

        // GET: SystemLanguageCodes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemLanguageCodePoco systemLanguageCodePoco = db.SystemLanguageCodes.Find(id);
            if (systemLanguageCodePoco == null)
            {
                return HttpNotFound();
            }
            return View(systemLanguageCodePoco);
        }

        // GET: SystemLanguageCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemLanguageCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LanguageID,Name,NativeName")] SystemLanguageCodePoco systemLanguageCodePoco)
        {
            if (ModelState.IsValid)
            {
                db.SystemLanguageCodes.Add(systemLanguageCodePoco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(systemLanguageCodePoco);
        }

        // GET: SystemLanguageCodes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemLanguageCodePoco systemLanguageCodePoco = db.SystemLanguageCodes.Find(id);
            if (systemLanguageCodePoco == null)
            {
                return HttpNotFound();
            }
            return View(systemLanguageCodePoco);
        }

        // POST: SystemLanguageCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LanguageID,Name,NativeName")] SystemLanguageCodePoco systemLanguageCodePoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(systemLanguageCodePoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(systemLanguageCodePoco);
        }

        // GET: SystemLanguageCodes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemLanguageCodePoco systemLanguageCodePoco = db.SystemLanguageCodes.Find(id);
            if (systemLanguageCodePoco == null)
            {
                return HttpNotFound();
            }
            return View(systemLanguageCodePoco);
        }

        // POST: SystemLanguageCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SystemLanguageCodePoco systemLanguageCodePoco = db.SystemLanguageCodes.Find(id);
            db.SystemLanguageCodes.Remove(systemLanguageCodePoco);
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
