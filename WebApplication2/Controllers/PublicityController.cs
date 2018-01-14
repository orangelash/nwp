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
    public class PublicityController : Controller
    {
        private PublicityDBContext db = new PublicityDBContext();

        // GET: Publicity
        public ActionResult Index()
        {
            return View(db.Publicity.ToList());
        }

        // GET: Publicity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicity publicity = db.Publicity.Find(id);
            if (publicity == null)
            {
                return HttpNotFound();
            }
            return View(publicity);
        }

        // GET: Publicity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publicity/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Title,Owner,Description,Content,Start,End,Parent_Beacon_id")] Publicity publicity)
        {
            if (ModelState.IsValid)
            {
                db.Publicity.Add(publicity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publicity);
        }

        // GET: Publicity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicity publicity = db.Publicity.Find(id);
            if (publicity == null)
            {
                return HttpNotFound();
            }
            return View(publicity);
        }

        // POST: Publicity/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Title,Owner,Description,Content,Start,End,Parent_Beacon_id")] Publicity publicity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publicity);
        }

        // GET: Publicity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicity publicity = db.Publicity.Find(id);
            if (publicity == null)
            {
                return HttpNotFound();
            }
            return View(publicity);
        }

        // POST: Publicity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publicity publicity = db.Publicity.Find(id);
            db.Publicity.Remove(publicity);
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
