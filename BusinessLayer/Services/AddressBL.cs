using BusinessLayer.Interfaces;
using ModelLayer.Services;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class AddressBL : IAddressBL
    {
        IAddressRL addressRL;
        public AddressBL(IAddressRL addressRL)
        {
            this.addressRL = addressRL;
        }

        public string AddAddress(AddressModel addressModel)
        {
            try
            {
                return this.addressRL.AddAddress(addressModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string DeleteAddress(int AddressId)
        {
            try
            {
                return this.addressRL.DeleteAddress(AddressId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AddressModel> GetAddressById(int UserId)
        {
            try
            {
                return this.addressRL.GetAddressById(UserId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AddressModel> GetAllAddress()
        {
            try
            {
                return this.addressRL.GetAllAddress();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string UpdateAddress(AddressModel addressModel)
        {
            try
            {
                return this.addressRL.UpdateAddress(addressModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
