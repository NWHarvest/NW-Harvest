﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NWHarvest.Web.Models;

namespace NWHarvest.Web.Controllers
{
    public class GrowersController : Controller
    {
        private NWHarvestEntities db = new NWHarvestEntities();

        // GET: Growers
        public ActionResult Index()
        {
            return View(db.Farmers.ToList());
        }

        // GET: Growers/DashboardView
        public ActionResult DashboardView()
        {
            return View();
        }

        // GET: Growers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grower grower = db.Farmers.Find(id);
            if (grower == null)
            {
                return HttpNotFound();
            }
            return View(grower);
        }

        // GET: Growers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Growers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,phone,email")] Grower grower)
        {
            if (ModelState.IsValid)
            {
                db.Farmers.Add(grower);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grower);
        }

        // GET: Growers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grower grower = db.Farmers.Find(id);
            if (grower == null)
            {
                return HttpNotFound();
            }
            return View(grower);
        }

        // POST: Growers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,phone,email")] Grower grower)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grower).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grower);
        }

        // GET: Growers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grower grower = db.Farmers.Find(id);
            if (grower == null)
            {
                return HttpNotFound();
            }
            return View(grower);
        }

        // POST: Growers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grower grower = db.Farmers.Find(id);
            db.Farmers.Remove(grower);
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