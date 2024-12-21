using E_WeddingDressShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices.Internal;
using System.Security.Cryptography;
using System.Text;
using System.Web.ApplicationServices;

namespace E_WeddingDressShop.Controllers
{
    public class UserController
    {
        private readonly string SqlCon = "Data Source=bekend\\sqlexpress;Initial Catalog=E_WeddingDress;Integrated Security=True;TrustServerCertificate=True";

        public string RegisterUser(USER us)
        {
            try
            {
                using (var conn = new SqlConnection(SqlCon))
                {
                    conn.Open();

                    // Check nếu email đã tồn tại
                    string isEmailExisting = "SELECT COUNT(*) FROM tb_Users WHERE Email = @Email";
                    using (SqlCommand checkCmd = new SqlCommand(isEmailExisting, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", us.Email);
                        int userCount = (int)checkCmd.ExecuteScalar();

                        if (userCount > 0)
                        {
                            return "Email đã được đăng ký!";
                        }
                    }

                    // Băm mật khẩu trước khi lưu vào cơ sở dữ liệu
                    us.PasswordHash = HashPassword(us.PasswordHash);

                    // Thêm người dùng mới
                    string insertQuery = @"
                    INSERT INTO tb_Users (FullName, Email, PasswordHash, NumberPhone, Address, Role, CreatedDate) 
                    VALUES (@FullName, @Email, @PasswordHash, @NumberPhone, @Address, @Role, @CreatedDate)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        AddUserParameters(cmd, us);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Đăng ký thành công!";
            }
            catch (Exception ex)
            {
                return "Lỗi: Không thể thực hiện đăng ký. Vui lòng thử lại. " + ex.Message;
            }
        }

        public string LoginUser(string email, string plainPassword)
        {

            try
            {
                using (var conn = new SqlConnection(SqlCon))
                {
                    conn.Open();

                    string query = "SELECT UserID, FullName, PasswordHash, Role FROM tb_Users WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                string storedPasswordHash = (reader["PasswordHash"].ToString()).Trim() as string;

                                if (VerifyPassword(plainPassword, storedPasswordHash))
                                {

                                    return "Đăng nhập thành công!";
                                }
                                else
                                {
                                    return "Mật khẩu không đúng!" + "\nTrong data:\n" + storedPasswordHash;
                                }
                            }
                            else
                            {
                                // Không tìm thấy email
                                return "Email không tồn tại!";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Lỗi: Không thể thực hiện đăng nhập: " + ex.Message;
            }
        }

        public string UpdateUser(USER us)
        {
            try
            {
                using (var conn = new SqlConnection(SqlCon))
                {
                    conn.Open();

                    string updateQuery = @"
                    UPDATE tb_Users 
                    SET FullName = @FullName, Email = @Email, PasswordHash = @PasswordHash, 
                        NumberPhone = @NumberPhone, Address = @Address, Role = @Role, CreatedDate = @CreatedDate 
                    WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        AddUserParameters(cmd, us);
                        cmd.Parameters.AddWithValue("@UserID", us.UserID);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Cập nhật thành công!";
            }
            catch (Exception ex)
            {
                return "Lỗi: Không thể cập nhật thông tin người dùng. Vui lòng thử lại. " + ex.Message;
            }
        }

        public int getUserByEmail(string email)
        {
            int result = -1; 
            using (var conn = new SqlConnection(SqlCon))
            {
                string sql = "SELECT UserID FROM tb_Users WHERE Email = @Email";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    result = (int)dr["UserID"];
                }
                conn.Close();
            }
            return result;
        }

        private void AddUserParameters(SqlCommand cmd, USER user)
        {
            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = user.FullName;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user.Email;
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar).Value = user.PasswordHash;
            cmd.Parameters.Add("@NumberPhone", SqlDbType.NVarChar).Value = user.NumberPhone;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = user.Address;
            cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = user.Role;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = user.CreatedDate;
        }

        private string HashPassword(string password)
        {
            using (var sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool VerifyPassword(string plainPassword, string storedHash)
        {
            String hashOfInput = HashPassword(plainPassword).Trim();

            // return hashOfInput.Equals(storedHash); 
            return hashOfInput.Equals(storedHash.Trim(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
