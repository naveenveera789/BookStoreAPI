using ModelLayer.Services.BookModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IBookRL
    {
        void AddBook(BookModel bookModel);
        void UpdateBook(BookModel bookModel);
        void DeleteBook(BookModel bookModel);
        BookModel GetBookData(int? BookId);
        List<BookModel> GetAllBookData();
    }
}
