using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services.BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookBL bookBL;
        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }

        [HttpPost]
        public ActionResult AddBook(BookModel bookModel)
        {
            try
            {
                this.bookBL.AddBook(bookModel);
                return this.Ok(new { success = true, message = $"Book {bookModel.BookName} added Successfully" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public ActionResult GetBookData(int? BookId)
        {
            try
            {
                if (BookId == null)
                {
                    return this.BadRequest(new { success = false, message = "Enter the Book ID" });
                }
                var result = this.bookBL.GetBookData(BookId);
                return this.Ok(new { success = true, message = $"The table data for BookId {result.BookId} is ", response = result });
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public ActionResult GetAllBookData()
        {
            try
            {
                List<BookModel> bookModels = new List<BookModel>();
                bookModels = this.bookBL.GetAllBookData().ToList();
                if(bookModels != null)
                {
                    return this.Ok(new { success = true, message = $"All Books list : ", response = bookModels });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = $"There are no books in the list"});
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Authorize]
        [HttpPut]
        public ActionResult UpdateBook(BookModel bookModel)
        {
            try
            {
                this.bookBL.UpdateBook(bookModel);
                return this.Ok(new { success = true, message = $"Book {bookModel.BookName} updated succesfully" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Authorize]
        [HttpDelete]
        public ActionResult DeleteBook(int? BookId)
        {
            try
            {
                if (BookId == null)
                {
                    return this.BadRequest(new { success = false, message = "Enter the Book ID" });
                }
                var result = this.bookBL.GetBookData(BookId);
                if (result != null)
                {
                    this.bookBL.DeleteBook(result);
                    return this.Ok(new { success = true, message = $"Book {result.BookName} deleted succesfully"});
                }
                else
                {
                    return this.BadRequest(new { success = false, message = $"Book {result.BookName} not deleted"});
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
