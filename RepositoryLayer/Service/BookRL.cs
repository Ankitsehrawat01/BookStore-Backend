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
    public class BookRL : IBookRL
    {
        private readonly IConfiguration iconfiguration;
        public BookRL(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDb;Integrated Security=True;");

        public BookModel addBook(BookModel bookModel)
        {
            using (con)
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_AddBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Book_Name", bookModel.Book_Name);
                    cmd.Parameters.AddWithValue("@Author_Name", bookModel.Author_Name);
                    cmd.Parameters.AddWithValue("@Price", bookModel.Price);
                    cmd.Parameters.AddWithValue("@Description", bookModel.Description);
                    cmd.Parameters.AddWithValue("@Rating", bookModel.Rating);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result != 0)
                    {
                        return bookModel;
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
        public bool deleteBook(long bookId)
        {
            using (con)
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result != 0)
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
        public BookModel UpdateBook(BookModel bookModel, long BookId)
        {
            using (con)
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_UpdateBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Book_Name", bookModel.Book_Name);
                    cmd.Parameters.AddWithValue("@Author_Name", bookModel.Author_Name);
                    cmd.Parameters.AddWithValue("@Price", bookModel.Price);
                    cmd.Parameters.AddWithValue("@Description", bookModel.Description);
                    cmd.Parameters.AddWithValue("@Rating", bookModel.Rating);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result != 0)
                    {
                        return bookModel;
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
