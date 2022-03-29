using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IAddressBL
    {
        string AddAddress(AddressModel addressModel);
        string UpdateAddress(AddressModel addressModel);
        string DeleteAddress(int AddressId);
        List<AddressModel> GetAllAddress();
        List<AddressModel> GetAddressById(int UserId);
    }
}
