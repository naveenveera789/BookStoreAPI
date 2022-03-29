using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IOrderRL
    {
        string AddOrder(OrderModel orderModel);
        string DeleteOrder(int OrderId);
        List<GetOrderModel> GetAllOrders(int UserId);
    }
}
