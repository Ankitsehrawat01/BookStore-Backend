using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CommonLayer.Model;

namespace RepositoryLayer.Service
{
    public class AdminRL : IAdminRL
    {
        private readonly IConfiguration iconfiguration;
        public AdminRL(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDb;Integrated Security=True;");
        
        public string adminLogin(LoginModel loginModel)
        {
            using (con)
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_AdminLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email_Id", loginModel.Email_Id);
                    cmd.Parameters.AddWithValue("@Password", loginModel.Password);
                    con.Open();
                    var rd = cmd.ExecuteScalar();
                    if(rd!=null) 
                    {
                        string query = "SELECT AdminId FROM AdminTable WHERE Email_Id = '" + rd + "'";
                        SqlCommand cmd1 = new SqlCommand(query, con);
                        var Id = cmd1.ExecuteScalar();
                        var token = GenerateJWTToken(loginModel.Email_Id, loginModel.UserId);
                        return token;
                    }
                    return null;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }
        }
        public string GenerateJWTToken(string email, long userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(iconfiguration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Email, email),
                    new Claim("UserId", userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
