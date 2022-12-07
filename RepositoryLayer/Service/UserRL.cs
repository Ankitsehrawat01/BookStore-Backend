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
        public UserRL(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDb;Integrated Security=True;");
        public UserRegistrationModel registerUser(UserRegistrationModel userRegistrationModel)
        {
            // SqlConnection con = new SqlConnection(this.iconfiguration.GetConnectionString("DBConnection"));
            // SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDb;Integrated Security=True;");
            using (con)
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_Register", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FullName", userRegistrationModel.FullName);
                    cmd.Parameters.AddWithValue("@Email_Id", userRegistrationModel.Email_Id);
                    cmd.Parameters.AddWithValue("@Password", userRegistrationModel.Password);
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
        public string userLogin(string email, string password)
        {
            using (con)
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_Login", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email_Id", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            email = Convert.ToString(rd["Email_Id"] == DBNull.Value ? default : rd["Email_Id"]);
                            password = Convert.ToString(rd["Password"] == DBNull.Value ? default : rd["Password"]);
                        }
                        var token = this.GenerateJWTToken(email);
                        return token;
                    }
                    return null;
                }
                catch (Exception)
                {

                    throw;
                }
        }
        public string GenerateJWTToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(iconfiguration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Email_Id", email) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string ForgetPassword(string Emailid)
        {
            using (con)
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_ForgetPassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email_Id", Emailid);
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            Emailid = Convert.ToString(rd["Email_Id"] == DBNull.Value ? default : rd["Email_Id"]);
                        }
                        var token = this.GenerateJWTToken(Emailid);
                        MSMQ msmq = new MSMQ();
                        msmq.sendData2Queue(token);
                        return token;
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
                    cmd.Parameters.AddWithValue("@Password", newpassword);
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
    }
}

