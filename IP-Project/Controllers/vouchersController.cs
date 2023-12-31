using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class vouchersController : Controller
    {
        private TopG_clothingEntities2 db = new TopG_clothingEntities2();


        public decimal CheckAndUseVoucher(string voucherCode, int personId)
        {
            // Find the voucher based on the voucher code
            var voucher = db.vouchers.FirstOrDefault(v => v.voucher_code == voucherCode && v.voucher_qty > 0);

            if (voucher != null)
            {
                // Check if the voucher is available for the given person ID
                var voucherCustomer = db.voucherCustomers.FirstOrDefault(vc => vc.voucher_id == voucher.voucher_id && vc.person_id == personId);

                if (voucherCustomer == null)
                {
                    ViewBag.Message = "This voucher is not available for this person.";
                    return 0;
                }

                // If enough quantity is available, use the voucher
                if (voucher.voucher_qty > 0 && voucherCustomer.voucher_usage < voucher.voucher_qty)
                {
                    voucherCustomer.voucher_usage++;
                    voucher.voucher_qty--;
                    db.SaveChanges();
                    return (decimal)(voucher.voucher_value ?? 0); 
                }

                else
                    {
                    ViewBag.Message = "Insufficient quantity available for this voucher.";
                    return 0;
                }
            }
            else
            {
                ViewBag.Message = "Invalid voucher code.";
                return 0;
            }
        }

        // GET: vouchers
        public ActionResult Index()
        {
            return View(db.vouchers.ToList());
        }

        public ActionResult CheckVoucher(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                ViewBag.Message = "Please provide a search string.";
                return View(); // You might return an error view or handle this case differently
            }

            var vouchers = db.vouchers.Where(v => v.voucher_code.Contains(searchString)).ToList();

            if (vouchers.Any())
            {
                ViewBag.Message = $"The search string '{searchString}' is present in voucher codes.";
                return View(); // You might return a view displaying the vouchers that contain the search string
            }
            else
            {
                ViewBag.Message = $"The search string '{searchString}' is not present in any voucher code.";
                return View(); // You might return a view indicating no matches were found
            }
        }

        // GET: vouchers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voucher voucher = db.vouchers.Find(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }

        // GET: vouchers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vouchers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "voucher_id,voucher_code,voucher_value,voucher_qty")] voucher voucher)
        {
            if (ModelState.IsValid)
            {
                db.vouchers.Add(voucher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(voucher);
        }

        // GET: vouchers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voucher voucher = db.vouchers.Find(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }

        // POST: vouchers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "voucher_id,voucher_code,voucher_value,voucher_qty")] voucher voucher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voucher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voucher);
        }

        // GET: vouchers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voucher voucher = db.vouchers.Find(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }

        // POST: vouchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            voucher voucher = db.vouchers.Find(id);
            db.vouchers.Remove(voucher);
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
