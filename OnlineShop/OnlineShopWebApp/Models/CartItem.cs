﻿using System;

namespace OnlineShopWebApp.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public ProductViewModel Product { get; set; }
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
