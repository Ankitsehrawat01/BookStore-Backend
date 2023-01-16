using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListBL iwishListBL;
        public WishListController(IWishListBL iwishListBL)
        {
            this.iwishListBL = iwishListBL;
        }

        [Authorize]
        [HttpPost]
        [Route("Add")]
        public IActionResult AddWishList(long BookId)
        {
            try
            {
                //var currentUser = HttpContext.User;
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = iwishListBL.AddWishList( BookId, UserId);
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
        [Authorize]
        [HttpDelete]
        [Route("Delete")]
        public IActionResult deleteWishList(long WishListId)
        {
            try
            {
                //var currentUser = HttpContext.User;
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);

                var result = iwishListBL.deleteWishList(WishListId, userId);

                if (result != false)
                {
                    return Ok( new {success = true, message = "WishList Deleted" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "WishList Not Deleted" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpGet("GetWishList")]
        public IActionResult GetWishList()
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iwishListBL.getWishList(UserId);
                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Wishlist Retrieved", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Retrieve Unsuccessful" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
