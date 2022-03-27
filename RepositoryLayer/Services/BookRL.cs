using Microsoft.Extensions.Configuration;
using ModelLayer.Services;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class BookRL : IBookRL
    {
        private SqlConnection con;
        private readonly IConfiguration configuration;
        public BookRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void AddBook(BookModel bookModel)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("AddBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookName", bookModel.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                    cmd.Parameters.AddWithValue("@DiscountPrice", bookModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@OriginalPrice", bookModel.OriginalPrice);
                    cmd.Parameters.AddWithValue("@BookDescription", bookModel.BookDescription);
                    cmd.Parameters.AddWithValue("@Rating",bookModel.Rating);
                    cmd.Parameters.AddWithValue("@Image", bookModel.Image);
                    cmd.Parameters.AddWithValue("@ReviewCount", bookModel.ReviewCount);
                    cmd.Parameters.AddWithValue("@BookCount", bookModel.BookCount);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }


        public List<BookModel> bookList = new List<BookModel>();
        public List<BookModel> GetAllBookData()
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("GetAllBooks", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    con.Open();
                    da.Fill(dt);
                    foreach(DataRow dr in dt.Rows)
                    {
                        bookList.Add(
                        new BookModel
                        {
                            BookId = Convert.ToInt32(dr["BookId"]),
                            BookName = dr["BookName"].ToString(),
                            AuthorName = dr["AuthorName"].ToString(),
                            DiscountPrice = Convert.ToInt32(dr["DiscountPrice"]),
                            OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]),
                            BookDescription = dr["BookDescription"].ToString(),
                            Rating = Convert.ToDouble(dr["Rating"]),
                            Image = dr["Image"].ToString(),
                            ReviewCount = Convert.ToInt32(dr["ReviewCount"]),
                            BookCount = Convert.ToInt32(dr["BookCount"])
                        }
                        );
                    }
                }
                return bookList;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public BookModel GetBookData(int? BookId)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                BookModel bookModel = new BookModel();
                using (con)
                {
                    string sqlQuery = "SELECT * FROM BookTable WHERE BookId= " + BookId;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bookModel.BookId = Convert.ToInt32(dr["BookId"]);
                        bookModel.BookName = dr["BookName"].ToString();
                        bookModel.AuthorName = dr["AuthorName"].ToString();
                        bookModel.DiscountPrice = Convert.ToInt32(dr["DiscountPrice"]);
                        bookModel.OriginalPrice = Convert.ToInt32(dr["OriginalPrice"]);
                        bookModel.BookDescription = dr["BookDescription"].ToString();
                        bookModel.Rating = Convert.ToDouble(dr["Rating"]);
                        bookModel.Image = dr["Image"].ToString();
                        bookModel.ReviewCount = Convert.ToInt32(dr["ReviewCount"]);
                        bookModel.BookCount = Convert.ToInt32(dr["BookCount"]);
                    }
                }
                return bookModel;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateBook(BookModel bookModel)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("UpdateBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookModel.BookId);
                    cmd.Parameters.AddWithValue("@BookName", bookModel.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                    cmd.Parameters.AddWithValue("@DiscountPrice", bookModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@OriginalPrice", bookModel.OriginalPrice);
                    cmd.Parameters.AddWithValue("@BookDescription", bookModel.BookDescription);
                    cmd.Parameters.AddWithValue("@Rating", bookModel.Rating);
                    cmd.Parameters.AddWithValue("@Image", bookModel.Image);
                    cmd.Parameters.AddWithValue("@ReviewCount", bookModel.ReviewCount);
                    cmd.Parameters.AddWithValue("@BookCount", bookModel.BookCount);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteBook(BookModel bookModel)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("DeleteBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookModel.BookId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }
    }
}