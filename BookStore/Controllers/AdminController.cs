using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBL iadminBL;
        public AdminController(IAdminBL iadminBL)
        {
            this.iadminBL = iadminBL;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult adminLogin(LoginModel loginModel)
        {
            try
            {
                string tokenString = iadminBL.adminLogin(loginModel);
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
