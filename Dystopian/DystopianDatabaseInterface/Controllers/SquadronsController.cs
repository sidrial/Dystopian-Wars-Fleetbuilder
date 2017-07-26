using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Entities;

namespace DystopianDatabaseInterface.Controllers
{
    public class SquadronsController : Controller
    {
        private DystopianRepository db = new DystopianRepository();

        // GET: Squadrons
        public ActionResult Index()
        {
            return View(db.Squadrons.ToList());
        }

        // GET: Squadrons/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Squadron squadron = db.Squadrons.Find(id);
            if (squadron == null)
            {
                return HttpNotFound();
            }
            return View(squadron);
        }

        // GET: Squadrons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Squadrons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Squadron squadron)
        {
            if (ModelState.IsValid)
            {
                squadron.ID = Guid.NewGuid();
                db.Squadrons.Add(squadron);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(squadron);
        }

        // GET: Squadrons/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Squadron squadron = db.Squadrons.Find(id);
            if (squadron == null)
            {
                return HttpNotFound();
            }
            return View(squadron);
        }

        // POST: Squadrons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Squadron squadron)
        {
            if (ModelState.IsValid)
            {
                db.Entry(squadron).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(squadron);
        }

        // GET: Squadrons/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Squadron squadron = db.Squadrons.Find(id);
            if (squadron == null)
            {
                return HttpNotFound();
            }
            return View(squadron);
        }

        // POST: Squadrons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Squadron squadron = db.Squadrons.Find(id);
            db.Squadrons.Remove(squadron);
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
