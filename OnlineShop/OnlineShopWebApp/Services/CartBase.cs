﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services
{
    public class CartBase
    {
        public static List<Cart> Сarts { get; set; } = new List<Cart>();

        public Cart TryGetByUserId(string userId)
        {
            return Сarts.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            Product = product,
                            Quantinity = 1
                        }
                    }
                };
                Сarts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantinity += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Id = Guid.NewGuid(),
                        Product = product,
                        Quantinity = 1
                    });

                }
            }

        }
    }
}
