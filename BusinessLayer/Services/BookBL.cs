using BusinessLayer.Interfaces;
using ModelLayer.Services.BookModel;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class BookBL : IBookBL
    {
        IBookRL bookRL;
        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }

        public void AddBook(BookModel bookModel)
        {
            try
            {
                this.bookRL.AddBook(bookModel);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void DeleteBook(BookModel bookModel)
        {
            try
            {
                this.bookRL.DeleteBook(bookModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<BookModel> GetAllBookData()
        {
            try
            {
                return this.bookRL.GetAllBookData();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public BookModel GetBookData(int? BookId)
        {
            try
            {
                return this.bookRL.GetBookData(BookId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateBook(BookModel bookModel)
        {
            try
            {
                this.bookRL.UpdateBook(bookModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
