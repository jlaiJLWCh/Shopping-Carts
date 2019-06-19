using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping_Cart.Models.Cart
{
    [Serializable]
    public class Cart : IEnumerable<CartItem>
    {   
        public Cart()
        {
            this.cartItems = new List<CartItem>();
        }

        private List<CartItem> cartItems;

        public int Count
        {
            get
            {
                return this.cartItems.Count;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                decimal totalAmount= 0.0m;
                foreach(var cartItem in this.cartItems)
                {
                    totalAmount += cartItem.Amount;
                }
                return totalAmount;
            }
        }

        public bool AddProduct(int ProductId)
        {
            var findItem = this.cartItems.Where(s => s.Id == ProductId).Select(s => s).FirstOrDefault();

            if(findItem == default(Models.Cart.CartItem))
            {
                using(Models.ShoppingCartEntities db = new Models.ShoppingCartEntities())
                {
                    var product = (from s in db.Products where s.Id == ProductId select s).FirstOrDefault();
                    if(product != default(Models.Product))
                    {
                        this.AddProduct(product);
                    }
                }
            }
            else
            {
                findItem.Quantity += 1;
            }

            return true;
        }

        private bool AddProduct(Product product)
        {
            var cartItem = new Models.Cart.CartItem()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = 1
            };

            this.cartItems.Add(cartItem);
            return true;
        }

        public bool RemoveProduct(int ProductId)
        {
            var findItem = this.cartItems.Where(s => s.Id == ProductId).Select(s => s).FirstOrDefault();

            if (findItem == default(Models.Cart.CartItem))
            {
                
            }
            else
            {
                this.cartItems.Remove(findItem);
            }

            return true;
        }

        public bool ClearCart()
        {
            this.cartItems.Clear();

            return true;
        }

        //透過cartItems實作介面
        public IEnumerator<CartItem> GetEnumerator()
        {
            return ((IEnumerable<CartItem>)cartItems).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<CartItem>)cartItems).GetEnumerator();
        }
    }
}