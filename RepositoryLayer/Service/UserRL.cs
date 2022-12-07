using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly IConfiguration iconfiguration;
        public UserRL( IConfiguration iconfiguration)
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
    }
}
