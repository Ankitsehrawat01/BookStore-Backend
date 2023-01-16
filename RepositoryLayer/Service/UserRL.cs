using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly IConfiguration iconfiguration;
        public string Key = "ankit@@sehrawat@@";
        public UserRL(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDb;Integrated Security=True;");
        public UserRegistrationModel registerUser(UserRegistrationModel userRegistrationModel)
        {
            using (con)
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_Register", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FullName", userRegistrationModel.FullName);
                    cmd.Parameters.AddWithValue("@Email_Id", userRegistrationModel.Email_Id);
                    cmd.Parameters.AddWithValue("@Password", EncryptPassword(userRegistrationModel.Password));
                    cmd.Parameters.AddWithValue("@Mobile_Number", userRegistrationModel.Mobile_Number);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result != 0)
                    {
                        return userRegistrationModel;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
        }
        public string userLogin(LoginModel loginModel)
        {
            using (con)
            {
                try
                {
                    SqlCommand command = new SqlCommand("Sp_Login", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email_Id", loginModel.Email_Id);
                    command.Parameters.AddWithValue("@Password", EncryptPassword(loginModel.Password));
                    con.Open();
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string query = "SELECT UserId FROM UserTable WHERE EmaiL_Id = '" + loginModel.Email_Id + "'";
                        //string query2 = "SELECT UserId FROM UserTable WHERE Password = '" + DecryptPassword(loginModel.Password) + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        var Id = cmd.ExecuteScalar();
                        var token = GenerateSecurityToken(loginModel.Email_Id, Id.ToString());
                        return token;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public string GenerateSecurityToken(string email, string UserId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.iconfiguration[("JWT:Key")]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim(ClaimTypes.Email, email),
                    new Claim("UserId", UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

        public string ForgetPassword(string Email_Id)
        {
            using (con)
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_ForgetPassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email_Id", Email_Id);
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            var userId = Convert.ToInt32(rd["UserId"] == DBNull.Value ? default : rd["UserId"]);
                            var token = this.GenerateSecurityToken(Email_Id, userId.ToString());
                            MSMQ msmq = new MSMQ();
                            msmq.sendData2Queue(token);
                            return token;
                        }
                        
                    }
                    con.Close();
                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
        }
        public bool ResetPassword(string email, string newpassword, string confirmpassword)
        {
            try
            {
                if (newpassword == confirmpassword)
                {
                    SqlCommand cmd = new SqlCommand("Sp_ResetPassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email_Id", email);
                    cmd.Parameters.AddWithValue("@Password", EncryptPassword(newpassword));
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            email = Convert.ToString(rd["Email_Id"] == DBNull.Value ? default : rd["Email_Id"]);
                            newpassword = Convert.ToString(rd["Password"] == DBNull.Value ? default : rd["Password"]);
                        }
                        return true;
                    }
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string EncryptPassword(string password)
        {
            try
            {
                if (string.IsNullOrEmpty(password))
                {
                    return "";
                }
                else
                {
                    password += Key;
                    var passwordBytes = Encoding.UTF8.GetBytes(password);
                    return Convert.ToBase64String(passwordBytes);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string DecryptPassword(string base64EncodeData)
        {
            try
            {
                if (string.IsNullOrEmpty(base64EncodeData))
                {
                    return "";
                }
                else
                {
                    var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
                    var result = Encoding.UTF8.GetString(base64EncodeBytes);
                    result = result.Substring(0, result.Length - Key.Length);
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

