using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IBookBL
    {
        void AddBook(BookModel bookModel);
        void UpdateBook(BookModel bookModel);
        void DeleteBook(BookModel bookModel);
        BookModel GetBookData(int? BookId);
        List<BookModel> GetAllBookData();
    }
}
