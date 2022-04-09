﻿using System;

namespace OnlineShopWebApp.Services
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantinity { get; set; }

        public decimal Cost
        {
            get
            {
                return Product.Cost * Quantinity;
            }
        }

    }
}
