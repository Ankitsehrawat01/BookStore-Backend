using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AdminBL : IAdminBL
    {
        private readonly IAdminRL iadminRL;

        public AdminBL(IAdminRL iadminRL)
        {
            this.iadminRL = iadminRL;
        }

        public string adminLogin(LoginModel loginModel)
        {
            try
            {
                return iadminRL.adminLogin(loginModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
