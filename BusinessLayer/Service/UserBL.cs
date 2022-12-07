using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL iuserRL;

        public UserBL(IUserRL iuserRL)
        {
            this.iuserRL = iuserRL;
        }

        public UserRegistrationModel registerUser(UserRegistrationModel userRegistrationModel)
        {
            try
            {
                return iuserRL.registerUser(userRegistrationModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string userLogin(string email, string password)
        {
            try
            {
                return iuserRL.userLogin(email, password);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string ForgetPassword(string Emailid)
        {
            try
            {
                return iuserRL.ForgetPassword(Emailid);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ResetPassword(string email, string newpassword, string confirmpassword)
        {
            try
            {
                return iuserRL.ResetPassword(email, newpassword, confirmpassword);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
