﻿using System;

namespace OnlineShop.DB.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantinity { get; set; }
        public Guid CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
