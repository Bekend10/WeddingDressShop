using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.DTO;
using System.EnterpriseServices.Internal;
using System.Security.Cryptography;
using System.Text;
namespace E_WeddingDressShop.Views.Clients
{
    public partial class UpdateUser : System.Web.UI.Page
    {
        UserController usercontroller = new UserController();
        CategoryController categoryController = new CategoryController();

        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["UserEmail"].ToString();
            int userID = usercontroller.getUserByEmail(email);
            string userName = usercontroller.getUserByUserID(userID).FullName;
            nameUser.InnerText = "Xin chào " + userName.ToString();
            Loaded();
            LoadCategory();

        }
        private bool checkPassword()
        {
            return txtmatkhau.Text == txtnhaplaimatkhau.Text;
        }

        protected void Loaded()
        {
            string email = Session["UserEmail"].ToString();
            int userId = usercontroller.getUserByEmail(email);
            USER u = usercontroller.layUserByUserID(userId);
            txthoten.Text = u.FullName;
            txtemail.Text = u.Email;
            txtdiachi.Text = u.Address;
            txtphonenumber.Text = u.NumberPhone;
        }
        protected void UpdateUserNe(object sender, CommandEventArgs e)
        {
            try
            {
                string email = Session["UserEmail"].ToString();
                int userId = usercontroller.getUserByEmail(email);
                USER u = usercontroller.layUserByUserID(userId);


                u.FullName = txthoten.Text;
                u.Email = txtemail.Text;
                u.NumberPhone = txtphonenumber.Text;
                u.Address = txtdiachi.Text;
                if (checkPassword() == false)
                {
                    lblErrorMessage.Text = "Mật khẩu không trùng khớp";
                    return;
                }
                u.PasswordHash = usercontroller.HashPassword(txtmatkhau.Text);
                string result = usercontroller.UpdateUser(u);
                lblErrorMessage.Text = result;
                Response.Redirect("~/Views/Clients/DashBoard.aspx");

            }
            catch (Exception e1) 
            {
                lblErrorMessage.Text = "Có lỗi xảy ra: " + e1.Message;
            }
        }
        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Views/Clients/Login.aspx");
        }
        protected void cbotheloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategoryID = cbotheloai.SelectedValue;

            Response.Redirect($"CategoryPage.aspx?CategoryID={selectedCategoryID}");
        }
        protected void LoadCategory()
        {
            var list = categoryController.getListCategory();
            cbotheloai.DataSource = list;
            cbotheloai.DataTextField = "CategoryName";
            cbotheloai.DataValueField = "CategoryID";
            //cbotheloai.Items.Insert(0, new ListItem("-- Select --", string.Empty));
            //cbotheloai.SelectedIndex = 0;
            cbotheloai.DataBind();
            cbotheloai.Items.Insert(0, new ListItem("-- Select --", ""));
        }
    }
}