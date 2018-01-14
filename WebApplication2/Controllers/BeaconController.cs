using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BeaconController : Controller
    {
        private BeaconDBContext db = new BeaconDBContext();

        // GET: Beacon
        public ActionResult Index()
        {
            return View(db.Beacon.ToList());
        }

        // GET: Beacon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beacon beacon = db.Beacon.Find(id);
            if (beacon == null)
            {
                return HttpNotFound();
            }
            return View(beacon);
        }

        // GET: Beacon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beacon/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Description,Store_id,Location")] Beacon beacon)
        {
            if (ModelState.IsValid)
            {
                db.Beacon.Add(beacon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beacon);
        }

        // GET: Beacon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beacon beacon = db.Beacon.Find(id);
            if (beacon == null)
            {
                return HttpNotFound();
            }
            return View(beacon);
        }

        // POST: Beacon/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Description,Store_id,Location")] Beacon beacon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beacon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beacon);
        }

        // GET: Beacon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beacon beacon = db.Beacon.Find(id);
            if (beacon == null)
            {
                return HttpNotFound();
            }
            return View(beacon);
        }

        // POST: Beacon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Beacon beacon = db.Beacon.Find(id);
            db.Beacon.Remove(beacon);
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


        public ActionResult RedirectToStore(int id)
        {
            return RedirectToAction("Details", "Stores", new { id = id });
        }
    }
}
