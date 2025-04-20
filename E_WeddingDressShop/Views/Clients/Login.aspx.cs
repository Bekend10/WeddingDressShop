using E_WeddingDressShop.Controllers;
using System;
using System.Web.UI;

namespace E_WeddingDressShop.Views
{
    public partial class Login : System.Web.UI.Page
    {
        UserController userController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] != null)
            {
                Response.Redirect("~/Views/Clients/Dashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Vui lòng nhập đầy đủ thông tin!";
                return;
            }

            UserController dto = new UserController();
            string result = dto.LoginUser(email, password);

            if (result == "Đăng nhập thành công!")
            {
                Session["UserEmail"] = email;                
                int userID = userController.getUserByEmail(email);
                string role = userController.getUserByUserID(userID).Role;
                if (role == "Admin")
                {
                    Response.Redirect("~/Views/Admin/Dashboard.aspx");
                }
                else
                {
                    Response.Redirect("~/Views/Clients/Dashboard.aspx");
                }
                Session["Role"] = role;           
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = result;
                txtPassword.Text = string.Empty;
            }
        }
    }
}
