using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderBL orderBL;
        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }

        [HttpPost]
        public ActionResult AddOrder(OrderModel orderModel)
        {
            try
            {
                string result = this.orderBL.AddOrder(orderModel);
                if (result.Equals("Order is placed successfully"))
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
        public ActionResult DeleteOrder(int OrderId)
        {
            try
            {
                string result = this.orderBL.DeleteOrder(OrderId);
                if (result.Equals("Order cancelled successfully"))
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
        public ActionResult GetAllOrders(int UserId)
        {
            try
            {
                var result = this.orderBL.GetAllOrders(UserId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "The Orders in the given UserId are : ", response = result });
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
