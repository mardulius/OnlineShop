﻿using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Cart
    {
        public static List<Product> Products { get; set; } = new List<Product>();

        public void AddToCart(Product product)
        {
            Products.Add(product);
        }

        public List<Product> TryGetAll()
        {
            return Products ?? null;
        }

        public void RemoveFromCart(Product product)
        {
            Products.Remove(product);
        }
    }
}
