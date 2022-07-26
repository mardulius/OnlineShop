using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineShop.DB.Models;
using OnlineShop.DB.Services;
using OnlineShopWebApp.Controllers;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace OnlineShopWebApp.Tests
{
    public class HomeControllerTests
    {
        private List<Product> products = new List<Product> {

            new Product

            {
                    Id = new Guid("8b4d6e1b-5223-4172-aaf6-f160518b101e"),
                    Name = "Букварь",
                    Cost = 356,
                    Description = "lorem...",
                    Images = new List<Image>
                    {
                        new Image
                        { Id = new Guid("81022697-a68b-49fd-b531-3c646af35f4d"),
                          Path = "/images/product/dsddsds.bmp",
                          ProductId = new Guid("8b4d6e1b-5223-4172-aaf6-f160518b101e")
                        }
                    }
            },

            new Product

            {
                    Id = new Guid("638f67fe-7951-4bd8-ad96-f3ea3eebf616"),
                    Name = "Неезнайка",
                    Cost = 690,
                    Description = "lorem...",
                    Images = new List<Image>
                    {
                        new Image
                        { Id = new Guid("0ed68e46-7aa2-41c2-9fe7-fc78080b3171"),
                          Path = "/images/product/dsddsds.bmp",
                          ProductId = new Guid("638f67fe-7951-4bd8-ad96-f3ea3eebf616")
                        }
                    }
            }
        };
        
        

        [Fact]
        public void IndexGetAllFromProductRepostoryListProductViewModel()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();
            mock.Setup(repository => repository.GetAllAsync()).ReturnsAsync(products);
            var controller = new HomeController(mock.Object);

            var expected = products.MappingToListProductViewModel();

            // Act
            var result = controller.Index().Result as ViewResult;
            var resultModel = result.Model as List<ProductViewModel>;

            // Assert

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ProductViewModel>>(resultModel);
            Assert.Equal(products.Count, resultModel.Count);
        }
    }
}
