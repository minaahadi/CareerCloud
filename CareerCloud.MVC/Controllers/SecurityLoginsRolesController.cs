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
    public class SecurityLoginsRolesController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: SecurityLoginsRoles
        public ActionResult Index()
        {
            var securityLoginsRoles = db.SecurityLoginsRoles.Include(s => s.SecurityLogin).Include(s => s.SecurityRole);
            return View(securityLoginsRoles.ToList());
        }

        // GET: SecurityLoginsRoles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginsRolePoco securityLoginsRolePoco = db.SecurityLoginsRoles.Find(id);
            if (securityLoginsRolePoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginsRolePoco);
        }

        // GET: SecurityLoginsRoles/Create
        public ActionResult Create()
        {
            ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "Login");
            ViewBag.Role = new SelectList(db.SecurityRoles, "Id", "Role");
            return View();
        }

        // POST: SecurityLoginsRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Role")] SecurityLoginsRolePoco securityLoginsRolePoco)
        {
            if (ModelState.IsValid)
            {
                securityLoginsRolePoco.Id = Guid.NewGuid();
                db.SecurityLoginsRoles.Add(securityLoginsRolePoco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "Login", securityLoginsRolePoco.Login);
            ViewBag.Role = new SelectList(db.SecurityRoles, "Id", "Role", securityLoginsRolePoco.Role);
            return View(securityLoginsRolePoco);
        }

        // GET: SecurityLoginsRoles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginsRolePoco securityLoginsRolePoco = db.SecurityLoginsRoles.Find(id);
            if (securityLoginsRolePoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "Login", securityLoginsRolePoco.Login);
            ViewBag.Role = new SelectList(db.SecurityRoles, "Id", "Role", securityLoginsRolePoco.Role);
            return View(securityLoginsRolePoco);
        }

        // POST: SecurityLoginsRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Role")] SecurityLoginsRolePoco securityLoginsRolePoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(securityLoginsRolePoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Login = new SelectList(db.SecurityLogin, "Id", "Login", securityLoginsRolePoco.Login);
            ViewBag.Role = new SelectList(db.SecurityRoles, "Id", "Role", securityLoginsRolePoco.Role);
            return View(securityLoginsRolePoco);
        }

        // GET: SecurityLoginsRoles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityLoginsRolePoco securityLoginsRolePoco = db.SecurityLoginsRoles.Find(id);
            if (securityLoginsRolePoco == null)
            {
                return HttpNotFound();
            }
            return View(securityLoginsRolePoco);
        }

        // POST: SecurityLoginsRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SecurityLoginsRolePoco securityLoginsRolePoco = db.SecurityLoginsRoles.Find(id);
            db.SecurityLoginsRoles.Remove(securityLoginsRolePoco);
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
