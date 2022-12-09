using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IBookRL
    {
        public BookModel addBook(BookModel bookModel);
        public bool deleteBook(long bookId);
        public BookModel UpdateBook(BookModel bookModel, long BookId);
    }
}
