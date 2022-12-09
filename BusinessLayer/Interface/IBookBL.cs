using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IBookBL
    {
        public BookModel addBook(BookModel bookModel);
        public bool deleteBook(long bookId);
    }
}
