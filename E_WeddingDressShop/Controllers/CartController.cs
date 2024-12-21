using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using E_WeddingDressShop.Models;

namespace E_WeddingDressShop.Controllers
{
    public class CartController
    {
        SqlConnection conn;

        public CartController()
        {
            string SqlCon = "Data Source=NQD-Desktop\\MSSQLSERVER01;Initial Catalog=E_WeddingDress;Integrated Security=True;Trust Server Certificate=True";
            conn = new SqlConnection(SqlCon);
        }

        private void AddCart(SqlCommand cmd, CART cart)
        {
            
        }
        private void RemoveItem(SqlCommand cmd, CART cart)
        {

        }
    }
}