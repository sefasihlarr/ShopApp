﻿using ShopApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface IOrderService
    {
        void Create(Order entity);
        List<Order> GetWithOrderId(int orderId);
        Order GetById(int id);

        List<Order> GetAllOrders();
        List<Order> GetOrders(string? userId);
    }
}
