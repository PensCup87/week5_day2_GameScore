using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using week5_day2_GameScore.Models;

namespace week5_day2_GameScore.Controllers
{
    public class ScoresController : Controller
    {
        /*creates the database that can only be accessed from the ScoresController*/
        private week5_day2_GameScoreContext db = new week5_day2_GameScoreContext();

        // GET: Scores; Information is being passed to the view as a parameter in View
        public ActionResult Index()
        {
            return View(db.Scores.ToList());// how view gets the information from the database(db); Has to BE LIST
        }

        // GET: Scores/Details/5
        public ActionResult Details(int? id)
        /* ? means optional The ID Allows db to grab the data
        for each entry and populate the method
        */
            {
            if (id == null)//if we do not pass through an ID - return an error because the ID does not exist
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Scores.Find(id);
            /*db is database; Scores is the MODEL; .Find(id) searches a record for a given ID ("ENTITY") from the previous IF
            there is a match then there is a new SCORE OBJECT and the model sends to the view
            
            Interview Material: Entity Framework - ORM REFERS TO TRANSLATING - maps objects to rows in database
             */
            if (score == null)//IF THE ID DOES NOT EXIST then send an Error
            {
                return HttpNotFound();
            }
            return View(score);//Entity is sent to the view
        }

        // GET: Scores/Create
        public ActionResult Create()
        {
            return View();
            //Returns the View that Allows New Record Entry
        }

        // POST: Scores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Points,Team")] Score score)
        {
            if (ModelState.IsValid)//makes sure the db is functioning properly before accepting information (BUILT IN)
            {
                db.Scores.Add(score);//adds a new score to the Scores Table
                db.SaveChanges();//actually adds information to the database
                return RedirectToAction("Index");//Takes user back to index page
            }

            return View(score);
        }

        // GET: Scores/Edit/5
        //GET WHEN A PAGE IS REQUESTED - POST IS WHEN A NEW PAGE IS DISPLAYED
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
            //Searches DB for an ID, if there is a match the score view is returned
        }

        // POST: Scores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Points,Team")] Score score)
        {
            if (ModelState.IsValid)
            {
                db.Entry(score).State = EntityState.Modified;//checks is score was modified
                db.SaveChanges();//saves the changes
                return RedirectToAction("Index");//shows index with updated values
            }
            return View(score);
        }

        // GET: Scores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // POST: Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Score score = db.Scores.Find(id);
            db.Scores.Remove(score);
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
