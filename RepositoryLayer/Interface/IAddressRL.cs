using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAddressRL
    {
        public AddressModel addAddress(AddressModel addressModel, long UserId);
        public AddressModel updateAddress(AddressModel addressModel, long AddressId, long UserId);
        public IEnumerable<AddressModel> getAddress(long UserId);
        public bool removeAddress(long AddressId);
    }
}
