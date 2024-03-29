﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping_Cart.Models.Cart
{
    [Serializable]
    public class CartItem
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public decimal Price {
            get;
            set;
        }

        public int Quantity {
            get;
            set;
        }

        public decimal Amount
        {
            get
            {
                return this.Price * this.Quantity;
            }
        }

        public string ImageUrl { get; set; }

        public bool StatusSale { get; set; }

        public int PriceDiscount { get; set; }
    }
}