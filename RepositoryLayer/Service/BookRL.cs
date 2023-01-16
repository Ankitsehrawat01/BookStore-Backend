using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
                    cmd.Parameters.AddWithValue("@Rating_Count", bookModel.Rating_Count);
                    cmd.Parameters.AddWithValue("@Discount_Price", bookModel.Discount_Price);
                    cmd.Parameters.AddWithValue("@Book_Quantity", bookModel.Book_Quantity);
                    cmd.Parameters.AddWithValue("@Book_Image", bookModel.Book_Image);


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
                    cmd.Parameters.AddWithValue("@BookId", BookId);
                    cmd.Parameters.AddWithValue("@Book_Name", bookModel.Book_Name);
                    cmd.Parameters.AddWithValue("@Author_Name", bookModel.Author_Name);
                    cmd.Parameters.AddWithValue("@Price", bookModel.Price);
                    cmd.Parameters.AddWithValue("@Description", bookModel.Description);
                    cmd.Parameters.AddWithValue("@Rating", bookModel.Rating);
                    cmd.Parameters.AddWithValue("@Rating_Count", bookModel.Rating_Count);
                    cmd.Parameters.AddWithValue("@Discount_Price", bookModel.Discount_Price);
                    cmd.Parameters.AddWithValue("@Book_Quantity", bookModel.Book_Quantity);
                    cmd.Parameters.AddWithValue("@Book_Image", bookModel.Book_Image);

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
        public List<BookModel> GetAllBooks()
        {
            using (con)
            try
            {
                List<BookModel> addBook = new List<BookModel>();
                SqlCommand cmd = new SqlCommand("Sp_Getallbooks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                dataAdapter.Fill(dt);
                foreach (DataRow rd in dt.Rows)
                {
                        addBook.Add(
                            new BookModel
                            {
                                BookId = Convert.ToInt32(rd["BookId"]),
                                Book_Name = rd["Book_Name"].ToString(),
                                Author_Name = rd["Author_Name"].ToString(),
                                Price = Convert.ToInt32(rd["Price"]),
                                Description = rd["Description"].ToString(),
                                Rating = rd["Rating"].ToString(),
                                Rating_Count = Convert.ToInt32(rd["Rating_Count"]),
                                Discount_Price = Convert.ToInt32(rd["Discount_Price"]),
                                Book_Quantity = Convert.ToInt32(rd["Book_Quantity"]),
                                Book_Image = rd["Book_Image"].ToString()
                            }
                            );
                }
                return addBook;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public object getBookById(long BookId)
        {
            using(con)
                try
                {
                    SqlCommand cmd = new SqlCommand("Sp_GetBookbyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", BookId);
                    con.Open();
                    BookModel bookModel = new BookModel();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            bookModel.BookId = Convert.ToInt32(rd["BookId"]);
                            bookModel.Book_Name = rd["Book_Name"].ToString();
                            bookModel.Author_Name = rd["Author_Name"].ToString();
                            bookModel.Price = Convert.ToInt32(rd["Price"]);
                            bookModel.Description = rd["Description"].ToString();
                            bookModel.Rating = rd["Rating"].ToString();
                            bookModel.Rating_Count = Convert.ToInt32(rd["Rating_Count"]);
                            bookModel.Discount_Price = Convert.ToInt32(rd["Discount_Price"]);
                            bookModel.Book_Quantity = Convert.ToInt32(rd["Book_Quantity"]);
                            bookModel.Book_Image = rd["Book_Image"].ToString();
                        }
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
