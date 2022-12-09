using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BusinessLayer.Service
{
    public class BookBL : IBookBL
    {
        private readonly IBookRL ibookRL;

        public BookBL(IBookRL ibookRL)
        {
            this.ibookRL = ibookRL;
        }
        public BookModel addBook(BookModel bookModel)
        {
            try
            {
                return ibookRL.addBook(bookModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool deleteBook(long bookId)
        {
            try
            {
                return ibookRL.deleteBook(bookId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public BookModel UpdateBook(BookModel bookModel, long BookId)
        {
            try
            {
                return ibookRL.UpdateBook(bookModel, BookId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<BookModel> GetAllBooks()
        {
            try
            {
                return ibookRL.GetAllBooks();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
