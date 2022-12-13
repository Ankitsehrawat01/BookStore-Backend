using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AddressBL : IAddressBL
    {
        private readonly IAddressRL iAddressRL;
        public AddressBL(IAddressRL iAddressRL)
        {
            this.iAddressRL = iAddressRL;
        }
        public AddressModel addAddress(AddressModel addressModel, long UserId)
        {
            try
            {
                return iAddressRL.addAddress(addressModel, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public AddressModel updateAddress(AddressModel addressModel, long AddressId, long UserId)
        {
            try
            {
                return iAddressRL.updateAddress(addressModel, AddressId, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<AddressModel> getAddress(long UserId)
        {
            try
            {
                return iAddressRL.getAddress(UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool removeAddress(long AddressId)
        {
            try
            {
                return iAddressRL.removeAddress(AddressId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
