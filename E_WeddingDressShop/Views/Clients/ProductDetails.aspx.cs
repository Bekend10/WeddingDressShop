using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.Models;

namespace E_WeddingDressShop.Views.Clients
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        ProductController productcontroller = new ProductController();
        CategoryController categorycontroller = new CategoryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string productIdStr = Request.QueryString["productId"];
                if (!String.IsNullOrEmpty(productIdStr))
                {
                    int productID = int.Parse(productIdStr);
                    var pro = productcontroller.getProductByID(productID);
                    if(pro!= null)
                    {
                        txttensp.Text = pro.Name;
                        txtgia.Text = pro.Price.ToString();
                        txtmota.Text = pro.Description;
                        txtsoluongcon.Text = pro.StockQuantity.ToString();
                        txttheloai.Text = categorycontroller.getCategoryNameByID(pro.CategoryID);
                        txtanh.Text = pro.ImageUrl;
                    }
                }

            }
            catch (Exception ex)
            {
                errmsg.Text = "Có lỗi xảy ra: " + ex.Message;
            }
        }
    }
}