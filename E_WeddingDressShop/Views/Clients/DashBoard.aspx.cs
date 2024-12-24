using E_WeddingDressShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_WeddingDressShop.Views
{
    public partial class DashBoard : System.Web.UI.Page
    {
        private UserController userController = new UserController();
        private ProductController productController = new ProductController();
        private const int PageSize = 8; // Số sản phẩm mỗi trang

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null)
            {
                Response.Redirect("~/Views/Clients/Login.aspx");
            }
            else
            {
                string email = Session["UserEmail"].ToString();
                int userID = userController.getUserByEmail(email);
                string userName = userController.getUserByUserID(userID).FullName;
                nameUser.InnerText = "Xin chào " + userName.ToString();
                if (!IsPostBack)
                {
                    LoadNewProducts();
                    LoadPagination();
                }
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Views/Clients/Login.aspx");
        }

        private void LoadNewProducts()
        {
            // Lấy trang hiện tại từ query string, mặc định là 1
            int currentPage = Convert.ToInt32(Request.QueryString["page"] ?? "1");

            // Lấy danh sách sản phẩm
            var products = productController.getListProduct();

            // Phân trang sản phẩm
            var pagedProducts = products
                .Skip((currentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            rptNewProducts.DataSource = pagedProducts;
            rptNewProducts.DataBind();
        }

        private void LoadPagination()
        {
            int currentPage = Convert.ToInt32(Request.QueryString["page"] ?? "1");

            var products = productController.getListProduct();
            int totalProducts = products.Count;

            int totalPages = (int)Math.Ceiling((double)totalProducts / PageSize);

            var pages = new List<dynamic>();
            for (int i = 1; i <= totalPages; i++)
            {
                pages.Add(new { PageNumber = i, Active = (i == currentPage) });
            }

            rptPagination.DataSource = pages;
            rptPagination.DataBind();
        }

    }
}
