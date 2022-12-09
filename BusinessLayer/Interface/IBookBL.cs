﻿using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IBookBL
    {
        public BookModel addBook(BookModel bookModel);
        public bool deleteBook(long bookId);
        public BookModel UpdateBook(BookModel bookModel, long BookId);
        public List<BookModel> GetAllBooks();
        public object getBookById(long BookId);
    }
}
