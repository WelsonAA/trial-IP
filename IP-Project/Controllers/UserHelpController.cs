using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Controllers

{
    public class UserHelpController : Controller
    {
        // GET: UserHelp
        private TopG_clothingEntities2 db = new TopG_clothingEntities2();
        public ActionResult feedback()
        {
            return View(db.feedbacks.ToList());
        }
 
        public ActionResult FAQ()
        {
            return View();
        }


        public ActionResult contact()
        {
            return View();
        }




        public string GetEmailByPersonId(int id)
        {
            var person = db.people.Find(id);

            return person.person_email;

        }

        // GET: stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedback deleted_feedback = db.feedbacks.Find(id);
            if (deleted_feedback == null)
            {
                return HttpNotFound();
            }
            return View(deleted_feedback);
        }

        // POST: stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            feedback deleted_feedback = db.feedbacks.Find(id);
            db.feedbacks.Remove(deleted_feedback);
            db.SaveChanges();
            return RedirectToAction("feedback");
        }




        [ActionName("Create")]

        public ActionResult Create()
        {
            return View();
        }

        // POST: stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "feedback_id,person_id,feedback_desc,feedback_date")] feedback newfeedback)
        {
            if (ModelState.IsValid)
            {
                var x = (int)Session["Per_person"];
                DateTime y = DateTime.Now;
                newfeedback.person_id = x;
                newfeedback.feedback_date = y;
                db.feedbacks.Add(newfeedback);
                db.SaveChanges();
                return RedirectToAction("feedback");

            }

            return View(newfeedback);

        }

        [ActionName("Edit_feedback")]
        // GET: stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedback editfeedback = db.feedbacks.Find(id);
            if (editfeedback == null)
            {
                return HttpNotFound();
            }
            return View(editfeedback);
        }



        // POST: stores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit_feedback")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "person_id,feedback_id,feedback_desc,feedback_date")] feedback editfeedback)
        {
            if (ModelState.IsValid)
            {
                var x = (int)Session["Per_person"];
                editfeedback.person_id = x;
                DateTime y = DateTime.Now;
                editfeedback.feedback_date = y;
                db.Entry(editfeedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("feedback");
            }
            return View(editfeedback);
        }


    }
}