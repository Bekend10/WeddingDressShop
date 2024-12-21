using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace E_WeddingDressShop.Models
{
    public class CART
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public CART(int cartID, int userID, int productID, int quantity)
        {
            CartID = cartID;
            UserID = userID;
            ProductID = productID;
            Quantity = quantity;
        }

        public CART()
        {
        }
    }
}