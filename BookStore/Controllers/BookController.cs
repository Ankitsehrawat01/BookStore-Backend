using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBL ibookBL;

        public BookController(IBookBL ibookBL)
        {
            this.ibookBL = ibookBL;
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult addBook(BookModel bookModel)
        {
            try
            {
                var result = ibookBL.addBook(bookModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Add Book successful", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Add Book unsuccessful" });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("Delete")]
        public IActionResult deleteBook(long bookId)
        {
            try
            {
                var result = ibookBL.deleteBook(bookId);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = "Book Deleted Sucessfull", Response = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to delete" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
