using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Net;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {

        // GET: Account
        //TASK OF LOGIN//
        private TopG_clothingEntities2 db = new TopG_clothingEntities2();


        public ActionResult Details(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            person person = db.people.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }
            person person = db.people.Find(id); 
            if (person == null) //if didn't exist
            {
                return HttpNotFound(); 
            }
            return View(person);  
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Edit([Bind(Include = "person_id,person_Fname,person_Lname,person_username,person_password,person_dob,person_email,person_phoneNo,person_address,person_role")] person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges(); 
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)  
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            person person = db.people.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) 
        {
            person person = db.people.Find(id);
            db.people.Remove(person); 
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        [ValidateAntiForgeryToken]
        public ActionResult login_post([Bind(Include = "person_email,person_password")] person per)
        {
            var rec = db.people.Where(x => x.person_email == per.person_email && x.person_password == per.person_password).FirstOrDefault();

            if (rec != null)
            {
                // Check if the email contains "@admin.com"
                if (rec.person_email.Contains("@admin.com"))
                {
                    Session["Per_role"] = "admin";
                  
                }
                else
                {
                    Session["Per_username"] = rec.person_Fname + " " + rec.person_Lname;
                    Session["Per_role"] = "user";
                    Session["Per_person"] = rec.person_id;
                    Session["Person_mail"] = rec.person_email;
                }
                Session["Login_valid"] = true;
            
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.error = "Sorry, Invalid user";
                return View(per);
            }
        }

        public ActionResult Index()
        {
            return View(db.people.ToList());
        }
        // GET: people/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "person_id,person_Fname,person_Lname,person_username,person_password,person_dob,person_email,person_phoneNo,person_address,person_role")] person person)
        {
            if (ModelState.IsValid)
            {
                // Check if the email is already taken
                if (db.people.Any(p => p.person_email == person.person_email))
                {
                    ModelState.AddModelError("person_email", "Email is already taken");
                    return View(person);
                }

                // Check if the email contains "@admin.com"
                if (person.person_email.Contains("@admin.com"))
                {
                    person.person_role = "admin";
                }
                else
                {
                    person.person_role = "user";
                }

                db.people.Add(person);
                db.SaveChanges();
                return RedirectToAction("Login", "Account");
            }

            return View(person);
        }

        public ActionResult Logout()
        {
            // Clear user-related session variables or perform any other logout actions
            Session["Login_valid"] = false;
            Session["Per_role"] = null;
            Session["Per_username"] = null;
            Session["Per_person"] = null;

            return RedirectToAction("Index", "Home");
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ForgetPassword")]
        [ValidateAntiForgeryToken]
        public ActionResult forgetPass_post([Bind(Include = "person_email,person_password")] person per, string person_newpass)
        {
            var rec = db.people.Where(x => x.person_email == per.person_email && x.person_password == per.person_password).FirstOrDefault();

            if (rec != null)
            {

                per.person_password = person_newpass;
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.error = "Sorry, Invalid email";
                return View(per);
            }
        }
    }
}
