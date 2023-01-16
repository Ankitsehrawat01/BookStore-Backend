using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusinessLayer.Service;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartBL icartBL;
        public CartController(ICartBL icartBL)
        {
            this.icartBL = icartBL;
        }
        [Authorize]
        [HttpPost]
        [Route("Add")]
        public ActionResult addCart(CartModel cartModel)
        {
            try
            {
                var currentUser = HttpContext.User;
                long UserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var response = icartBL.addCart(cartModel, UserId);

                if (response != null)
                {
                    return Ok(new { success = true, message = "Book added successfully", data = response });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Book Not Added", data = response });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpDelete]
        [Route ("Delete")]
        public ActionResult removeCart(int cartId)
        {
            try
            {
                var response = this.icartBL.removeCart(cartId);

                if (response != null)
                {
                    return this.Ok(new { success = true, message = "Delete Successfull", data = response });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Delete Unsuccessfull", data = response });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpGet]
        [Route ("GetCart")]
        public IActionResult getCart()
        {
            try
            {
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(g => g.Type == "UserId").Value);
                var result = icartBL.getCart(UserId);

                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Successful ", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Unsuccessful " });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPost]
        [Route ("Update")]
        public ActionResult updateCart(int cartId, CartModel cart)
        {
            try
            {
                var currentUser = HttpContext.User;
                int UserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);

                var result = icartBL.updateCart(cartId, cart, UserId);

                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Cart Updated", data = result });
                }
                return this.BadRequest(new { success = false, message = "Cart not updated", data = result });

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("GetById")]
        public IActionResult getCartById(long CartId)
        {
            try
            {
                var reg = icartBL.getCartById(CartId);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Book Details", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to get details" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
