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
    }
}
