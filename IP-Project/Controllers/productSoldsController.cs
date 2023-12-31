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
    public class productSoldsController : Controller
    {
        private TopG_clothingEntities2 db = new TopG_clothingEntities2();

        // GET: productSolds
        public ActionResult Index()
        {
            var productSolds = db.productSolds.Include(p => p.product);
            return View(productSolds.ToList());
        }

        // GET: productSolds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productSold productSold = db.productSolds.Find(id);
            if (productSold == null)
            {
                return HttpNotFound();
            }
            return View(productSold);
        }

    
    }
}
