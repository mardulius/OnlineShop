﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class Cart
    {

        public Guid Id { get; set; }
        public string UserId { get; set; }

        public List<CartItem> Items { get; set; }

        public decimal TotalCost
        {
            get { return Items.Sum(x => x.Cost); }
        }




    }
}
