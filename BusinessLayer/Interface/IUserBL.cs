using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public UserRegistrationModel registerUser(UserRegistrationModel userRegistrationModel);
        public string userLogin(string email, string password);
        public string ForgetPassword(string Emailid);
        public bool ResetPassword(string email, string newpassword, string confirmpassword);
    }
}
