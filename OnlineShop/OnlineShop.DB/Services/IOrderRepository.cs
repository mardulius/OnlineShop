﻿using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
    public interface IOrderRepository
    {
        List<Order> TryGetByUserId(string userId);
        List<Order> TryGetAll();
        void Add(Order order);
        void UpdateStatus(Guid orderId, OrderStatus status);
        Order TryGetById(Guid Id);
    }
}
