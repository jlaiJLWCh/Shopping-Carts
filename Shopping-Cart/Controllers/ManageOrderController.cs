﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping_Cart.Controllers
{
    public class ManageOrderController : Controller
    {
        // GET: ManageOrder
        public ActionResult Index()
        {
            Models.ShoppingCartEntities db = new Models.ShoppingCartEntities();
            var result = (from s in db.Orders select s).ToList();

            return View(result);
        }


        public ActionResult Detail(int id)
        {
            using(Models.ShoppingCartEntities db = new Models.ShoppingCartEntities())
            {
                var result = (from s in db.OrderDetails where s.Id == id select s).ToList();

                if(result.Count == 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(result);
                }
            }
        }
    }
}