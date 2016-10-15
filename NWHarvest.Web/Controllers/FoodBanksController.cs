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
    public class FoodBanksController : Controller
    {
        private NWHarvestEntities db = new NWHarvestEntities();

        // GET: FoodBanks
        public ActionResult Index()
        {
            return View(db.FoodBanks.ToList());
        }

        // GET: FoodBanks/DashboardView
        public ActionResult DashboardView()
        {
            return View();
        }

        // GET: FoodBanks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodBank foodBank = db.FoodBanks.Find(id);
            if (foodBank == null)
            {
                return HttpNotFound();
            }
            return View(foodBank);
        }

        // GET: FoodBanks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodBanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,phone,email,latlong")] FoodBank foodBank)
        {
            if (ModelState.IsValid)
            {
                db.FoodBanks.Add(foodBank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodBank);
        }

        // GET: FoodBanks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodBank foodBank = db.FoodBanks.Find(id);
            if (foodBank == null)
            {
                return HttpNotFound();
            }
            return View(foodBank);
        }

        // POST: FoodBanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,phone,email,latlong")] FoodBank foodBank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodBank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodBank);
        }

        // GET: FoodBanks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodBank foodBank = db.FoodBanks.Find(id);
            if (foodBank == null)
            {
                return HttpNotFound();
            }
            return View(foodBank);
        }

        // POST: FoodBanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodBank foodBank = db.FoodBanks.Find(id);
            db.FoodBanks.Remove(foodBank);
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
