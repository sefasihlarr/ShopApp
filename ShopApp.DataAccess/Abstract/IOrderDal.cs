﻿using ShopApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Abstract
{
    public interface IOrderDal : IRepository<Order>
    {
        List<Order> GetAllOrders();

        List<Order> GetWithOrderId(int orderId);
        List<Order> GetOrders(string? userId);
    }
}
