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
    public class WishlistRL : IWishlistRL
    {
        private SqlConnection con;
        private readonly IConfiguration configuration;
        public WishlistRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string AddBookToWishlist(WishlistModel wishlistModel)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("AddBookToWishlist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", wishlistModel.UserId);
                    cmd.Parameters.AddWithValue("@BookId", wishlistModel.BookId);  
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return "Book added to wishlist successfully";
                    }
                    else
                    {
                        return "Book is not added to wishlist";
                    }
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

        public string DeleteWishlist(int WishlistId)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("DeleteWishlist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WishlistId", WishlistId);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return "Wishlist deleted successfully";
                    }
                    else
                    {
                        return "Wishlist is not deleted";
                    }
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

        public List<GetWishlistModel> GetWishlistData(int UserId)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    List<GetWishlistModel> wishlist = new List<GetWishlistModel>();
                    SqlCommand cmd = new SqlCommand("GetWishlist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            GetWishlistModel wishlistModel = new GetWishlistModel();
                            BookModel bookModel = new BookModel();
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
                            wishlistModel.WishlistId = Convert.ToInt32(dr["WishlistId"]);
                            wishlistModel.UserId = Convert.ToInt32(dr["UserId"]);
                            wishlistModel.BookId = Convert.ToInt32(dr["BookId"]);
                            wishlistModel.bookModel = bookModel;
                            wishlist.Add(wishlistModel);
                        }
                        return wishlist;
                    }
                    else
                    {
                        return null;
                    }
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
