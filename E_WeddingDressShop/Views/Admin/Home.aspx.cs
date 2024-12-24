using E_WeddingDressShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_WeddingDressShop.Views.Admin
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStatistics();
            }
        }
        private void LoadStatistics()
        {
            try
            {
                // Tạo đối tượng controller để lấy dữ liệu thống kê
                var orderController = new OrderController();

                // Lấy tổng doanh thu và tỷ lệ đơn hàng hủy
                decimal totalRevenue = orderController.GetTotalRevenue();
                decimal cancellationRate = orderController.GetCancellationRate();

                // Hiển thị thông tin lên UI
                lblTotalRevenue.Text = totalRevenue.ToString("N0") + " VNĐ";
                lblCancellationRate.Text = cancellationRate.ToString("F2") + " %";
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (nếu có)
                lblTotalRevenue.Text = "Lỗi!";
                lblCancellationRate.Text = "Lỗi!";
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public decimal TinhToanTiLeCompletedPerMonth(int index)
        {
            var orderController = new OrderController();
            return orderController.GetCompletedRateByMonth(index);
        }
        public decimal getcompletedrateformbd()
        {
            var orderController = new OrderController();
            return orderController.GetCompletedRate();
        }
        public decimal getcanceledrateformbd()
        {
            var orderController = new OrderController();
            return orderController.GetCancellationRate();
        }
    }
}