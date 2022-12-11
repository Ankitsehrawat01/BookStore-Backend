using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminBL iadminBL;
        public AdminController(AdminBL iadminBL)
        {
            this.iadminBL = iadminBL;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult adminLogin(string email, string password)
        {
            try
            {
                string tokenString = iadminBL.adminLogin(email, password);
                if (tokenString != null)
                {
                    return Ok(new { Success = true, message = "login Sucessfull", Data = tokenString });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "login Unsucessfull" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
