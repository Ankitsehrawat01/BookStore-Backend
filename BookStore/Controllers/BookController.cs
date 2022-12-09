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
        [Route("Register")]
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
    }
}
