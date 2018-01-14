using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BeaconController : Controller
    {
        // GET: Beacon
        public ActionResult Index(string searchString, string beaconStore, string beaconLocation)
        { 

            var StoreLst = new List<string>();

            var StoreQry = from d in db.Beacon
                           orderby d.Store
                           select d.Store;

            StoreLst.AddRange(StoreQry.Distinct());
            ViewBag.beaconStore = new SelectList(StoreLst);


            var LocationLst = new List<string>();

            var LocationQry = from d in db.Beacon
                           orderby d.location
                           select d.location;

            LocationLst.AddRange(LocationQry.Distinct());
            ViewBag.beaconLocation = new SelectList(LocationLst);

            var beacon = from m in db.Beacon
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                beacon = beacon.Where(s => s.description.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(beaconStore))
            {
                beacon = beacon.Where(x => x.store == beaconStore);
            }

            if (!string.IsNullOrEmpty(beaconLocation))
            {
                beacon = beacon.Where(x => x.location == beaconLocation);
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            // get values from db
           
            return View();
        }

        [HttpPost]
        public ActionResult Edit_save([Bind(Include = "id,store,location,description")] Beacon beacon)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(beacon).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            return View(beacon);
        }





        public ActionResult Details()
        {


            return View();
        }

        public ActionResult Delete()
        {


            return View();
        }

        public ActionResult Create()
        {

            return View();

        }

    }
}