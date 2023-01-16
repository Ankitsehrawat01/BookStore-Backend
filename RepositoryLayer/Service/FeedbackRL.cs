using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
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
                    cmd.CommandType = CommandType.StoredProcedure;
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
        public IEnumerable<FeedbackModel> getFeedback( long BookId)
        {
            using (con)
            {
                try
                {
                    con.Open();
                    //String query = "SELECT FeedbackID, rating, Comment, BookID FROM FeedbackTable WHERE UserID = '" + UserId + "'";
                    SqlCommand cmd = new SqlCommand("spGetFeedback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId ", BookId);
                    SqlDataReader rd = cmd.ExecuteReader();
                    List<FeedbackModel> feedback = new List<FeedbackModel>();
                    while (rd.Read())
                    {
                        feedback.Add(new FeedbackModel()
                        {
                            FeedbackId = (long)rd["FeedbackId"],
                            Rating = (long)rd["Rating"],
                            Comment = rd["Comment"].ToString(),
                            BookId = (long)rd["BookId"],
                            UserId = Convert.ToInt32(rd["UserId"]),
                            FullName = rd["FullName"].ToString(),

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
        public object getFeedbackbyId(long FeedbackId, long UserId)
        {
            using (con)
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_GetfeedbackbyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FeedbackId", FeedbackId);
                    //cmd.Parameters.AddWithValue("@UserId", UserId);
                    con.Open();
                    FeedbackModel feedbackModel = new FeedbackModel();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            feedbackModel.FeedbackId = Convert.ToInt32(reader["FeedbackId"]);
                            feedbackModel.BookId = Convert.ToInt32(reader["BookId"]);
                            feedbackModel.UserId = Convert.ToInt32(reader["UserId"]);
                            feedbackModel.Rating = Convert.ToInt32(reader["Rating"]);
                            //feedbackModel.FullName = reader["FullName"].ToString();
                            feedbackModel.Comment = reader["Comment"].ToString();
                        }
                        return feedbackModel;
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
