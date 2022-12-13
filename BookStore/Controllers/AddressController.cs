using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressBL iAddressBL;
        public AddressController(IAddressBL iAddressBL)
        {
            this.iAddressBL = iAddressBL;
        }
        [Authorize]
        [HttpPost]
        [Route("Add")]
        public IActionResult addAddress(AddressModel addressModel)
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var response = iAddressBL.addAddress(addressModel, UserId);

                if (response != null)
                {
                    return Ok(new { success = true, message = "Address added successfully", data = response });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Address Not Added" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpPut]
        [Route("Update")]
        public IActionResult updateAddress(AddressModel addressModel, long AddressId)
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var response = iAddressBL.updateAddress(addressModel, AddressId, UserId);

                if (response != null)
                {
                    return Ok(new { success = true, message = "Address added successfully", data = response });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Address Not Added" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("Get")]
        public IActionResult getAddress(long UserId)
        {
            try
            {
                //long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var response = iAddressBL.getAddress(UserId);
                if (response != null) 
                {
                    return Ok(new { success = true, message = "Get Address Successfull", data = response });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Get Address Unsuccessfull"});
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("Delete")]
        public  IActionResult removeAddress(long AddressId)
        {
            try
            {
                var response = iAddressBL.getAddress(AddressId);
                if (response != null)
                {
                    return Ok(new { success = true, message = "Address Deleted"});
                }
                else
                {
                    return BadRequest(new { success = false, message = "Address not Deleted" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
