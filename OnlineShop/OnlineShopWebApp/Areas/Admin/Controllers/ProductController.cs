﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShop.DB.Services;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Const.AdminRoleName)]
    [Authorize(Roles = Const.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;

        }
        public IActionResult Index()
        {
            var products = productRepository.GetAll();
            var productsViewModel = products.MappingToListProductViewModel();
            return View(productsViewModel);
        }


        public IActionResult DeleteProduct(Guid id)
        {
            var product = productRepository.TryGetById(id);
            if (product != null)
            {
                productRepository.Delete(product);
            }
            return RedirectToAction("Index", "Product");
        }

        public IActionResult EditProduct(Guid id)
        {
            var product = productRepository.TryGetById(id);
            var productViewModel = product.MappingToProductViewModel();
            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult EditProduct(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var productDb = productViewModel.MappingToProduct();
                productRepository.Update(productDb);
            }

            return RedirectToAction("Index", "Product");
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel productViewModel)
        {
            var productDb = productViewModel.MappingToProduct();
            productRepository.Add(productDb);
            return RedirectToAction("Index", "Product");
        }

    }
}
