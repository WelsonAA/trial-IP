using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Controllers; // Import the namespace of vouchersController


public class CartController : Controller
{
    private TopG_clothingEntities2 db = new TopG_clothingEntities2();
    private vouchersController _voucherController = new vouchersController();

    public ActionResult Index()
    {
        // Assuming you have a way to identify the current user
        int userId = GetCurrentUserId();

        // Retrieve cart items for the specific user
        List<Cart_item> cart_Items = db.Cart_item.Where(c => c.User_id == userId).ToList();

        return View(cart_Items);
    }

    public ActionResult OrderDetails()
    {
        return View();
    }

    [HttpPost]
    public ActionResult AddToCart(int productId)
    {
        // Assuming you have a way to identify the current user
        int userId = GetCurrentUserId();
        

        // Check if the product is already in the cart
        var existingCartItem = db.Cart_item.FirstOrDefault(c => c.User_id == userId && c.product_id == productId);

        if (existingCartItem != null)
        {
            // Increment quantity if the product is already in the cart
            existingCartItem.cartItem_product_qty++;
            db.SaveChanges();
        }
        else
        {
            if (ModelState.IsValid)
            {
                // Add a new item to the cart if not already in the cart
                Cart_item newCartItem = new Cart_item
                {
                    User_id = userId,
                    product_id = productId,
                    cartItem_product_qty = 1  // You can set the initial quantity as needed
                };

                db.Cart_item.Add(newCartItem);
                db.SaveChanges();
            }

        }


        // Redirect back to the product page or wherever you want
        return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult RemoveFromCart(int productId)
    {
        // Assuming you have a way to identify the current user
        int userId = GetCurrentUserId();

        // Find the cart item to remove
        var cartItemToRemove = db.Cart_item.FirstOrDefault(c => c.User_id == userId && c.product_id == productId);

        if (cartItemToRemove != null)
        {
            // Remove the item from the cart
            db.Cart_item.Remove(cartItemToRemove);
            db.SaveChanges();
        }

        // Redirect back to the cart page
        return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult UpdateQuantity(int productId, string operation)
    {
        try
        {
            // Assuming you have a way to identify the current user
            int userId = GetCurrentUserId();

            var cartItem = db.Cart_item.FirstOrDefault(c => c.User_id == userId && c.product_id == productId);

            if (cartItem != null)
            {
                if (operation == "plus")
                {
                    cartItem.cartItem_product_qty++;
                }
                else if (operation == "minus" && cartItem.cartItem_product_qty > 1)
                {
                    cartItem.cartItem_product_qty--;
                }

                db.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, error = "Product not found in the user's cart" });
            }
        }
        catch (Exception ex)
        {
            // Log the exception or output details for debugging
            Console.WriteLine(ex.ToString());

            // Return a generic error response
            return Json(new { success = false, error = "An error occurred on the server." });
        }
    }

    [HttpPost]
    public ActionResult Checkout(string voucher)
    {
        
        // Get the user ID (you may need to implement user authentication)
        int userId = GetCurrentUserId(); // Replace this with the actual logic to get the user ID
        decimal voucherValue = _voucherController.CheckAndUseVoucher(voucher, userId);

        List<Cart_item> cartItems = db.Cart_item.Where(c => c.User_id == userId).ToList();
        if (cartItems.Count > 0)
        {
          
            // Create an order
            Order order = new Order
            {
                User_ID = userId,
                Order_Date = DateTime.Now,
                Total_Amount = 20 + cartItems.Sum(item => item.product.product_price * item.cartItem_product_qty) * (double)(1-voucherValue),
                Payment_Method = "Credit Card" // You can modify this based on your payment method handling
            }; // You need to calculate the total based on your cart items

            using (var context = new TopG_clothingEntities2())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
            // Create ProductSold records
            foreach (var cartItem in cartItems)
            {
                using (var context = new TopG_clothingEntities2())
                {
                    // Check if the productSold record already exists
                    var existingProductSold = context.productSolds
                        .SingleOrDefault(p => p.product_id == cartItem.product_id);

                    if (existingProductSold != null)
                    {
                        // If it exists, update the quantity
                        existingProductSold.product_quantity += cartItem.cartItem_product_qty;
                    }
                    else
                    {
                        // If it doesn't exist, create a new record
                        productSold productSold = new productSold
                        {
                            product_id = cartItem.product_id,
                            product_quantity = cartItem.cartItem_product_qty,
                            product_price = cartItem.product.product_price,
                            product_date = DateTime.Now
                        };

                        context.productSolds.Add(productSold);
                    }

                    context.SaveChanges();
                }
            }

            // Save the order to the database
            // Assuming you have a DbContext named ApplicationDbContext


            // Remove items from the cart (you need to implement this method)
            db.Cart_item.RemoveRange(cartItems);
            db.SaveChanges();

            // You can return a success message or redirect to a thank-you page
            // Prepare data for the view
            ViewBag.OrderId = order.Order_ID;
            ViewBag.OrderDate = order.Order_Date;
            ViewBag.TotalAmount = order.Total_Amount;

            // Redirect to the OrderDetails view
            return View("OrderDetails");
        }
        else
        {
            ViewBag.ErrorMessage = "Your cart is empty.";
            return View("Index", cartItems); // You can modify this based on your needs
        }
    }
    private int GetCurrentUserId()
    {
        // Replace this with your logic to get the current user's ID
        // Example: Retrieve user ID from session
        if (Session["Per_person"] != null && int.TryParse(Session["Per_person"].ToString(), out int userId))
        {
            return userId;
        }

        // Default value if user ID is not available
        return 0;
    }

}
