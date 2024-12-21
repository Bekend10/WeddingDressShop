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

        private string AddCart(CART cart)
        {
            try
            {
                string sql = "INSERT INTO tb_Carts (CartID, UserID, ProductID, Quantity) " +
                             "VALUES (@CartID, @UserID, @ProductID, @Quantity, @ImageUrl)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                AddCartParamater(cmd, cart);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Thêm giỏ hàng thành công!";
            }
            catch (Exception ex)
            {
                conn.Close();
                return "Lỗi khi thêm giỏ hàng: " + ex.Message;
            }
        }
        private string DeleteCart(int CartID)
        {
            try
            {
                string sql = "DELETE FROM tb_Carts WHERE CartID = @CartID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CartID", CartID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Xóa giỏ hàng thành công!";
            }
            catch (Exception ex)
            {
                conn.Close();
                return "Lỗi khi xóa giỏ hàng: " + ex.Message;
            }
        }

        private void AddCartParamater(SqlCommand cmd, CART cart)
        {
            cmd.Parameters.AddWithValue("@CartID", cart.CartID);
            cmd.Parameters.AddWithValue("@UserID", cart.UserID);
            cmd.Parameters.AddWithValue("@ProductID", cart.ProductID);
            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
        }
    }
}