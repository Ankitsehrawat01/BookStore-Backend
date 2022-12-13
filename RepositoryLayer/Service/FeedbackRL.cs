using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class FeedbackRL : IFeedbackRL
    {
        private readonly IConfiguration iconfiguration;
        public FeedbackRL(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDb;Integrated Security=True;");

        public bool addFeedback(FeedbackModel feedbackModel, long UserId)
        {
            using (con)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_Addfeedback", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Rating", feedbackModel.Rating);
                    cmd.Parameters.AddWithValue("@Comment", feedbackModel.Comment);
                    cmd.Parameters.AddWithValue("@BookId", feedbackModel.BookId);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public IEnumerable<FeedbackModel> getFeedback(long UserId)
        {
            using (con)
            {
                try
                {
                    con.Open();
                    String query = "SELECT FeedbackID, rating, Comment, BookID FROM FeedbackTable WHERE UserID = '" + UserId + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    List<FeedbackModel> feedback = new List<FeedbackModel>();
                    while (rd.Read())
                    {
                        feedback.Add(new FeedbackModel()
                        {
                            FeedbackId = (long)rd["FeedbackId"],
                            Rating = (long)rd["Rating"],
                            Comment = rd["Comment"].ToString(),
                            BookId = (long)rd["BookId"]

                        });
                    }
                    return feedback;
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
        }
    }
}
