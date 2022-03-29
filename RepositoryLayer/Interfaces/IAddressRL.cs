using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IAddressRL
    {
        string AddAddress(AddressModel addressModel);
        string UpdateAddress(AddressModel addressModel);
        string DeleteAddress(int AddressId);
        List<AddressModel> GetAllAddress();
        List<AddressModel> GetAddressById(int UserId);
    }
}
