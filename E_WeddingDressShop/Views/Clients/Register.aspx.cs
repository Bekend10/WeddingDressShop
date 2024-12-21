using E_WeddingDressShop.Controllers;
using E_WeddingDressShop.DTO;
using System;
using System.Text;
using System.Web.UI;

namespace E_WeddingDressShop.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string numberPhone = txtNumberPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string role = ddlRole.SelectedValue;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(numberPhone) ||
                string.IsNullOrEmpty(address))
            {
                return;
            }

            if (!IsValidEmail(email))
            {
                return;
            }

            if (password.Length < 8)
            {
                return;
            }

            if (!long.TryParse(numberPhone, out _) || numberPhone.Length < 9)
            {
                return;
            }

            USER user = new USER
            {
                FullName = fullName,
                Email = email,
                PasswordHash = password,
                NumberPhone = numberPhone,
                Address = address,
                Role = role,
                CreatedDate = DateTime.Now
            };

            UserController dto = new UserController();
            string result = dto.RegisterUser(user);
            string script;
            if (result.Contains("thành công"))
            {
                // Xóa các trường nhập sau khi đăng ký thành công
                txtFullName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtNumberPhone.Text = string.Empty;
                txtAddress.Text = string.Empty;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowToast", @"
                     function showToast(message) {
                         Toastify({
                             text: message,
                             duration: 3000,
                             close: true,
                             gravity: 'top',
                             position: 'right',
                             style.background: '#00d400',
                             stopOnFocus: true
                         }).showToast();
                     }
                 ", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ToastMessage", "showToast('Đăng ký thành công!');", true);
                Response.Redirect("~/Views/Clients/Login.aspx");
            }
            else
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowToast", @"
                     function showToast(message) {
                         Toastify({
                             text: message,
                             duration: 3000,
                             close: true,
                             gravity: 'top',
                             position: 'right',
                             backgroundColor: 'red',
                             stopOnFocus: true
                         }).showToast();
                     }
                 ", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ToastMessage", "showToast('Thông tin chưa chính xác!');", true);

            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
