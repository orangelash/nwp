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
    public class ManagementController : Controller
    {
        private ManagementDBContext db = new ManagementDBContext();

        // GET: Management
        public ActionResult Index()
        {
            return View(db.Management.ToList());
        }

        // GET: Management/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Management management = db.Management.Find(id);
            if (management == null)
            {
                return HttpNotFound();
            }
            return View(management);
        }

        // GET: Management/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Management/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Store_id,clearence")] Management management)
        {
            if (ModelState.IsValid)
            {
                db.Management.Add(management);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(management);
        }

        // GET: Management/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Management management = db.Management.Find(id);
            if (management == null)
            {
                return HttpNotFound();
            }
            return View(management);
        }

        // POST: Management/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Store_id,clearence")] Management management)
        {
            if (ModelState.IsValid)
            {
                db.Entry(management).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(management);
        }

        // GET: Management/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Management management = db.Management.Find(id);
            if (management == null)
            {
                return HttpNotFound();
            }
            return View(management);
        }

        // POST: Management/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Management management = db.Management.Find(id);
            db.Management.Remove(management);
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
