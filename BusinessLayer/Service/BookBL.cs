using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
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
    }
}
