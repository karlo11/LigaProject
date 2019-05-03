using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Liga.Models;

namespace Liga.Controllers
{
    public class ClubsController : Controller
    {
        private LeaguesManagerDbContext db = new LeaguesManagerDbContext();

        // GET: Clubs
        public ActionResult Index()
        {
            var clubs = db.Clubs.Include(c => c.League).Include(c => c.Manager).Include(c => c.Stadium);
            return View(clubs.ToList());
        }

        // GET: Clubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // GET: Clubs/Create
        public ActionResult Create()
        {
            ViewBag.LeagueID = new SelectList(db.Leagues, "ID", "Country");
            ViewBag.ID = new SelectList(db.Managers, "ID", "FirstName");
            ViewBag.StadiumID = new SelectList(db.Stadiums, "ID", "Name");
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LeagueID,StadiumID,Name,Email,DateOfFoundation,PhoneNumber")] Club club)
        {
            if (ModelState.IsValid)
            {
                db.Clubs.Add(club);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeagueID = new SelectList(db.Leagues, "ID", "Country", club.LeagueID);
            ViewBag.ID = new SelectList(db.Managers, "ID", "FirstName", club.ID);
            ViewBag.StadiumID = new SelectList(db.Stadiums, "ID", "Name", club.StadiumID);
            return View(club);
        }

        // GET: Clubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeagueID = new SelectList(db.Leagues, "ID", "Country", club.LeagueID);
            ViewBag.ID = new SelectList(db.Managers, "ID", "FirstName", club.ID);
            ViewBag.StadiumID = new SelectList(db.Stadiums, "ID", "Name", club.StadiumID);
            return View(club);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LeagueID,StadiumID,Name,Email,DateOfFoundation,PhoneNumber")] Club club)
        {
            if (ModelState.IsValid)
            {
                db.Entry(club).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeagueID = new SelectList(db.Leagues, "ID", "Country", club.LeagueID);
            ViewBag.ID = new SelectList(db.Managers, "ID", "FirstName", club.ID);
            ViewBag.StadiumID = new SelectList(db.Stadiums, "ID", "Name", club.StadiumID);
            return View(club);
        }

        // GET: Clubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Club club = db.Clubs.Find(id);
            db.Clubs.Remove(club);
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
