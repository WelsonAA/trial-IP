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
    public class OrdersController : Controller
    {
        private TopG_clothingEntities2 db = new TopG_clothingEntities2();

        // GET: Orders
        public ActionResult Index()
        {
            // Check if the user is logged in
            if (Session["Per_person"] != null)
            {
                int userId = (int)Session["Per_person"];

                // Retrieve orders for the logged-in user
                var orders = db.Orders.Where(o => o.User_ID == userId).Include(o => o.person);

                return View(orders.ToList());
            }
            else
            {
                // Handle the case where the user is not logged in
                // For example, redirect them to the login page
                return RedirectToAction("Login", "Account");
            }
        }


        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

    }
}
