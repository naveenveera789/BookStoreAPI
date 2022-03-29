using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        IAddressBL addressBL;
        public AddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }

        [HttpPost]
        public ActionResult AddAddress(AddressModel addressModel)
        {
            try
            {
                string result = this.addressBL.AddAddress(addressModel);
                if (result.Equals("Address added successfully"))
                {
                    return this.Ok(new { success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut]
        public ActionResult UpdateAddress(AddressModel addressModel)
        {
            try
            {
                string result = this.addressBL.UpdateAddress(addressModel);
                if (result.Equals("Address updated successfully"))
                {
                    return this.Ok(new { success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete]
        public ActionResult DeleteAddress(int AddressId)
        {
            try
            {
                string result = this.addressBL.DeleteAddress(AddressId);
                if (result.Equals("Address deleted successfully"))
                {
                    return this.Ok(new { success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public ActionResult GetAddressById(int UserId)
        {
            try
            {
                var result = this.addressBL.GetAddressById(UserId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "The Addresses in the given UserId are : ", response = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public ActionResult GetAllAddress()
        {
            try
            {
                var result = this.addressBL.GetAllAddress();
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "The Addresses are : ", response = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
