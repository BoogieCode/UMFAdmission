using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UMFAdmission.Models;

namespace UMFAdmission.Controllers
{
    public class MultipleChoiceQuestionsController : Controller
    {
        private AdmissionUMFDBTestEntities db = new AdmissionUMFDBTestEntities();

        // GET: MultipleChoiceQuestions
        public ActionResult Index()
        {
            return View(db.MultipleChoiceQuestions.ToList());
        }

        // GET: MultipleChoiceQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultipleChoiceQuestion multipleChoiceQuestion = db.MultipleChoiceQuestions.Find(id);
            if (multipleChoiceQuestion == null)
            {
                return HttpNotFound();
            }
            return View(multipleChoiceQuestion);
        }

        // GET: MultipleChoiceQuestions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MultipleChoiceQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionID,Question,A,B,C,D,AnswerA,AnswerB,AnswerC,AnswerD")] MultipleChoiceQuestion multipleChoiceQuestion)
        {
            if (ModelState.IsValid)
            {
                db.MultipleChoiceQuestions.Add(multipleChoiceQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(multipleChoiceQuestion);
        }

        // GET: MultipleChoiceQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultipleChoiceQuestion multipleChoiceQuestion = db.MultipleChoiceQuestions.Find(id);
            if (multipleChoiceQuestion == null)
            {
                return HttpNotFound();
            }
            return View(multipleChoiceQuestion);
        }

        // POST: MultipleChoiceQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionID,Question,A,B,C,D,AnswerA,AnswerB,AnswerC,AnswerD")] MultipleChoiceQuestion multipleChoiceQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(multipleChoiceQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(multipleChoiceQuestion);
        }

        // GET: MultipleChoiceQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultipleChoiceQuestion multipleChoiceQuestion = db.MultipleChoiceQuestions.Find(id);
            if (multipleChoiceQuestion == null)
            {
                return HttpNotFound();
            }
            return View(multipleChoiceQuestion);
        }

        // POST: MultipleChoiceQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MultipleChoiceQuestion multipleChoiceQuestion = db.MultipleChoiceQuestions.Find(id);
            db.MultipleChoiceQuestions.Remove(multipleChoiceQuestion);
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
