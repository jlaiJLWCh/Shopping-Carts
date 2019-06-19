using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping_Cart.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.OrderModel.Ship postback)
        {
            if (this.ModelState.IsValid)
            {
                var currentcart = Models.Cart.Operation.GetCurrentCart();

                var userId = HttpContext.User.Identity.GetUserId();

                using (Models.ShoppingCartEntities db = new Models.ShoppingCartEntities())
                {
                    var order = new Models.Order()
                    {
                        UserId = userId,
                        RecieverName = postback.RecieverName,
                        RecieverAddress = postback.RecieverAddress,
                        RecieverPhone = postback.RecieverPhone
                    };

                    db.Orders.Add(order);
                    db.SaveChanges();

                    var orderDetails = currentcart.ToOrderDetailList(order.Id);

                    db.OrderDetails.AddRange(orderDetails);
                    db.SaveChanges();
                }
                return Content("訂購成功");
            }
            return View();
        }
    }
}