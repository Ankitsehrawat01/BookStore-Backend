using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL iuserBL;

        public UserController(IUserBL iuserBL)
        {
            this.iuserBL = iuserBL;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult RegisterUser(UserRegistrationModel userRegistrationModel)
        {
            try
            {
                var result = iuserBL.registerUser(userRegistrationModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Registration successful", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Registration unsuccessful" });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult userLogin(string email, string password)
        {
            try
            {
                string tokenString = iuserBL.userLogin(email, password);
                if (tokenString != null)
                {
                    return Ok(new { Success = true, message = "login Sucessfull", Data = tokenString });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "login Unsucessfull" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("ForgetPassword")]
        public IActionResult ForgetPassword(string email)
        {
            try
            {
                string token = iuserBL.ForgetPassword(email);
                if (token != null)
                {
                    return Ok(new { success = true, Message = "Please check your Email.Token sent succesfully." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, Message = "Email not registered" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPost("Reset")]
        public IActionResult ResetPassword(string newpassword, string confirmpassword)
        {
            try
            {
                var email = User.FindFirst("Email_Id").Value.ToString();
                var data = iuserBL.ResetPassword(email, newpassword, confirmpassword);
                if (data != null)
                {
                    if (newpassword == confirmpassword)
                    {
                        return this.Ok(new { Success = true, message = "Your password has been changed sucessfully" });
                    }
                    else
                    {
                        return this.Ok(new { Success = true, message = "Password dont matched" });
                    }

                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to reset password.Please try again" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
