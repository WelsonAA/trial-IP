using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;

using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products

        private TopG_clothingEntities2 db = new TopG_clothingEntities2();

        public ActionResult WomenHoodies()
        {
            List<product> womenHoodies = db.products.Where(p => p.product_type == "WomenHoodie").ToList();
            return View(womenHoodies);
        }


        public ActionResult MenHoodies()
        {
            List<product> menHoodies = db.products.Where(p => p.product_type == "MenHoodie").ToList();
            return View(menHoodies);
        }
        public ActionResult Shirts()
        {
            List<product> shirts = db.products.Where(p => p.product_type == "Shirt").ToList();
            return View(shirts);
        }

        public ActionResult SunGlasses()
        {
            List<product> sunGlasses = db.products.Where(p => p.product_type == "Sunglasses").ToList();
            return View(sunGlasses);
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(GetProductTypeRedirect(product.product_type));
            }
            return View(product);
        }


        public ActionResult Delete (int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product); 
            db.SaveChanges();
            return RedirectToAction(GetProductTypeRedirect(product.product_type));
        }
        // Helper method to get the appropriate redirect action based on the product type
        private string GetProductTypeRedirect(string productType)
        {
            switch (productType)
            {
                case "MenHoodie":
                    return "MenHoodies";
                case "WomenHoodie":
                    return "WomenHoodies";
                case "Shirt":
                    return "Shirts";
                case "Sunglasses":
                    return "SunGlasses";
                // Add more cases if needed
                default:
                    return "Index";
            }
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: people/Create
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct([Bind(Include = "product_id,product_brand_name,product_price,product_desc,product_qty,product_type,product_size,product_rating,product_image")] product product)
        {
            if (ModelState.IsValid)
            {
                
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: product details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public ActionResult DetailsBack(int id)
        {
            product product = db.products.Find(id);
            return RedirectToAction(GetProductTypeRedirect(product.product_type));
        }





    }
}