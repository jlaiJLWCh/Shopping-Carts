using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping_Cart.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Models.Product> result = new List<Models.Product>();

            Models.ShoppingCartEntities db = new Models.ShoppingCartEntities();
            result = (from s in db.Products select s).ToList();

            ViewBag.ResultMessage = TempData["ResultMessage"];

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Product postback)
        {
            if (this.ModelState.IsValid)
            {
                using (Models.ShoppingCartEntities db = new Models.ShoppingCartEntities())
                {
                    db.Products.Add(postback);

                    db.SaveChanges();

                    TempData["ResultMessage"] = String.Format("商品[{0}]成功建立 ", postback.Name);

                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            using(Models.ShoppingCartEntities db = new Models.ShoppingCartEntities())
            {
                var result = (from product in db.Products where product.Id == id select product).FirstOrDefault();
                if( result != default( Models.Product))
                {

                }

            }
            return View();
        }
        
         

    }
}