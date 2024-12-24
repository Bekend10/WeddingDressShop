using E_WeddingDressShop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_WeddingDressShop.Controllers
{
    public class OrderController
    {
        SqlConnection conn;

        public OrderController()
        {
            //string SqlCon = "Data Source=bekend\\sqlexpress;Initial Catalog=E_WeddingDress;Integrated Security=True;TrustServerCertificate=True";
            string SqlCon = "Data Source=LAP;Initial Catalog=E_WeddingDress;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            conn = new SqlConnection(SqlCon);
        }

        private void AddParameters(SqlCommand cmd, ORDER order)
        {
            cmd.Parameters.AddWithValue("@UserID", order.UserID);
            cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
            cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
            cmd.Parameters.AddWithValue("@Status", order.Status);
        }

        public List<ORDER> getListOrderForClient(int userID)
        {
            var list = new List<ORDER>();
            string sql = @"SELECT * from tb_Orders where UserID = @UserID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserID", userID);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ORDER cate = new ORDER
                {
                    OrderID = (int)dr["OrderID"],
                    OrderDate = (DateTime)dr["OrderDate"],
                    TotalAmount = (Decimal)dr["TotalAmount"],
                    Status = (string)dr["Status"],
                    UserID = (int)dr["UserID"],
                };
                list.Add(cate);
            }
            conn.Close();
            return list;
        }

        public List<ORDER> getListOrder()
        {
            var list = new List<ORDER>();
            string sql = "SELECT o.OrderID ,o.UserID , u.FullName , o.TotalAmount, o.OrderDate , o.Status  FROM tb_Orders o\r\ninner join tb_Users u on u.UserID = o.UserID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ORDER cate = new ORDER
                {
                    OrderID = (int)dr["OrderID"],
                    OrderDate = (DateTime)dr["OrderDate"],
                    TotalAmount = (Decimal)dr["TotalAmount"],
                    Status = (string)dr["Status"],
                    UserID = (int)dr["UserID"],
                    FullName = (string)dr["FullName"]
                };
                list.Add(cate);
            }
            conn.Close();
            return list;
        }

        public ORDER getORDERByID(int ORDERID)
        {
            string sql = @"SELECT o.OrderID , o.UserID , u.FullName , o.TotalAmount, o.OrderDate , o.Status  FROM tb_Orders o
                inner join tb_Users u on u.UserID = o.UserID WHERE OrderID = @ORDERID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ORDERID", ORDERID);
            conn.Open();
            ORDER cate = null;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cate = new ORDER
                {
                    OrderID = (int)dr["OrderID"],
                    OrderDate = (DateTime)dr["OrderDate"],
                    TotalAmount = (Decimal)dr["TotalAmount"],
                    Status = (string)dr["Status"],
                    UserID = (int)dr["UserID"],
                    FullName = (string)dr["FullName"]
                };
            }
            conn.Close();
            return cate;
        }

        public string AddORDER(ORDER cate)
        {
            try
            {
                string sql = "INSERT INTO tb_Orders (UserID, OrderDate , TotalAmount , Status) VALUES (@UserID , @OrderDate, @TotalAmount , @Status)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                AddParameters(cmd, cate);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Thêm danh mục thành công!";
            }
            catch (Exception ex)
            {
                conn.Close();
                return "Lỗi: " + ex.Message;
            }
        }

        public string UpdateORDER(ORDER cate)
        {
            try
            {
                string sql = @"
                UPDATE tb_Orders
                SET OrderDate = @OrderDate, TotalAmount = @TotalAmount,
                Status = @Status
                WHERE OrderID = @ORDERID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                AddParameters(cmd, cate);
                cmd.Parameters.AddWithValue("@ORDERID", cate.OrderID);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0 ? "Cập nhật đơn hàng thành công!" : "Không tìm thấy đơn hàng để cập nhật!";
            }
            catch (Exception ex)
            {
                conn.Close();
                return "Lỗi: " + ex.Message;
            }
        }

        public string DeleteORDER(int ORDERID)
        {
            try
            {
                string sql = "DELETE FROM tb_Orders WHERE OrderID = @ORDERID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ORDERID", ORDERID);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0 ? "Xóa danh mục thành công!" : "Không tìm thấy danh mục để xóa!";
            }
            catch (Exception ex)
            {
                conn.Close();
                return "Lỗi: " + ex.Message;
            }
        }

        public decimal GetTotalRevenue()
        {
            decimal totalRevenue = 0;
            try
            {
                string sql = @"SELECT SUM(TotalAmount) as TotalRevenue FROM tb_Orders WHERE Status = 'Completed'"; // Hoặc trạng thái tương ứng
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                object result = cmd.ExecuteScalar();
                totalRevenue = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception("Lỗi khi tính tổng doanh thu: " + ex.Message);
            }
            return totalRevenue;
        }

        public decimal GetCancellationRate()
        {
            decimal cancellationRate = 0;
            try
            {
                // Lấy tổng số đơn hàng
                string sqlTotalOrders = "SELECT COUNT(*) FROM tb_Orders";
                SqlCommand cmdTotalOrders = new SqlCommand(sqlTotalOrders, conn);
                conn.Open();
                int totalOrders = Convert.ToInt32(cmdTotalOrders.ExecuteScalar());

                // Lấy số đơn hàng hủy
                string sqlCancelledOrders = "SELECT COUNT(*) FROM tb_Orders WHERE Status = 'Cancle'"; // Trạng thái hủy của bạn
                SqlCommand cmdCancelledOrders = new SqlCommand(sqlCancelledOrders, conn);
                int cancelledOrders = Convert.ToInt32(cmdCancelledOrders.ExecuteScalar());
                conn.Close();

                // Tính tỷ lệ hủy
                if (totalOrders > 0)
                {
                    cancellationRate = (decimal)cancelledOrders / totalOrders * 100; // Chuyển thành phần trăm
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception("Lỗi khi tính tỷ lệ đơn hàng hủy: " + ex.Message);
            }
            return cancellationRate;
        }
        public decimal GetCompletedRate()
        {
            decimal CompletedRate = 0;
            try
            {
                // Lấy tổng số đơn hàng
                string sqlTotalOrders = "SELECT COUNT(*) FROM tb_Orders";
                SqlCommand cmdTotalOrders = new SqlCommand(sqlTotalOrders, conn);
                conn.Open();
                int totalOrders = Convert.ToInt32(cmdTotalOrders.ExecuteScalar());

                // Lấy số đơn hàng thành công
                string sqlCompletedOrders = "SELECT COUNT(*) FROM tb_Orders WHERE Status = 'Completed'"; // Trạng thái hủy của bạn
                SqlCommand cmdCompletedOrders = new SqlCommand(sqlCompletedOrders, conn);
                int cancelledOrders = Convert.ToInt32(cmdCompletedOrders.ExecuteScalar());
                conn.Close();

                // Tính tỷ lệ thành công
                if (totalOrders > 0)
                {
                    CompletedRate = (decimal)cancelledOrders / totalOrders * 100; // Chuyển thành phần trăm
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception("Lỗi khi tính tỷ lệ đơn hàng Thành công: " + ex.Message);
            }
            return CompletedRate;
        }
        
        public decimal GetCompletedRateByMonth(int month)
        {
            decimal completedRate = 0;
            try
            {
                // Lấy tổng số đơn hàng theo tháng
                string sqlTotalOrders = @"SELECT COUNT(*) 
                                  FROM tb_Orders 
                                  WHERE MONTH(OrderDate) = @month";
                SqlCommand cmdTotalOrders = new SqlCommand(sqlTotalOrders, conn);
                cmdTotalOrders.Parameters.AddWithValue("@month", month);
                conn.Open();
                int totalOrders = Convert.ToInt32(cmdTotalOrders.ExecuteScalar());

                // Lấy số đơn hàng thành công theo tháng
                string sqlCompletedOrders = @"SELECT COUNT(*) 
                                      FROM tb_Orders 
                                      WHERE Status = 'Completed' AND MONTH(OrderDate) = @month";
                SqlCommand cmdCompletedOrders = new SqlCommand(sqlCompletedOrders, conn);
                cmdCompletedOrders.Parameters.AddWithValue("@month", month);
                int completedOrders = Convert.ToInt32(cmdCompletedOrders.ExecuteScalar());
                conn.Close();

                // Tính tỷ lệ thành công
                if (totalOrders > 0)
                {
                    completedRate = (decimal)completedOrders / totalOrders * 100; // Chuyển thành phần trăm
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception("Lỗi khi tính tỷ lệ đơn hàng thành công theo tháng: " + ex.Message);
            }
            return completedRate;
        }

    }
}