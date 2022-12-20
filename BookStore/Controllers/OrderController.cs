using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using BusinessLayer.Service;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBL iOrderBL;
        public OrderController(IOrderBL iOrderBL)
        {
            this.iOrderBL = iOrderBL;
        }
        [Authorize]
        [HttpPost]
        [Route("Add")]
        public IActionResult addOrder(OrderModel orderModel)
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var response = iOrderBL.addOrder(orderModel, UserId);

                if (response != null)
                {
                    return Ok(new { success = true, message = "Order Placed successfully", data = response });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Order not Placed" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("DeleteOrder")]
        public IActionResult DeleteOrder(long OrderId)
        {
            try
            {
                var result = iOrderBL.CancelOrder(OrderId);
                if (result)
                {
                    return Ok(new { success = true, message = "Order cancelled successfully." });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cannot cancel order." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("GetOrder")]
        public IActionResult GetAllOrders()
        {
            try
            {
                int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(g => g.Type == "UserId").Value);
                var result = iOrderBL.GetAllOrders();

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
    }
}
