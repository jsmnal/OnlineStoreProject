using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineStoreProject.Controllers;
using OnlineStoreProject.Data.DAL;
using OnlineStoreProject.Data.DAL.Interfaces;
using OnlineStoreProject.Models;
using OnlineStoreProject.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineStoreProject.UnitTests.Controllers
{
    public class ShopBasketsControllerTests
    {
        private readonly Mock<IShopBasketService> serviceStub = new Mock<IShopBasketService>();
        private readonly Mock<IHttpContextAccessor> httpContextAccessorStub = new Mock<IHttpContextAccessor>();
        private readonly Random rand = new();

        [Fact]
        public async Task GetShopBasket_WithUnExistingShopBasket_ReturnsNotFound()
        {
            serviceStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((ShopBasket)null);

            var controller = new ShopBasketsController(serviceStub.Object, httpContextAccessorStub.Object);

            var result = await controller.GetShopBasket(4);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]

        public async Task GetShopBasket_WithExistingShopBasket_ReturnExpectedShopBasket()
        {
            var expectedShopBasket = CreateRandomShopBasket();
            serviceStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(expectedShopBasket);
            var controller = new ShopBasketsController(serviceStub.Object, httpContextAccessorStub.Object);

            var result = await controller.GetShopBasket(3);

            Assert.IsType<ShopBasket>(result.Value);
            result.Value.Should().BeEquivalentTo(expectedShopBasket, options => options.ComparingByMembers<ShopBasket>());
        }

        [Fact]

        public async Task GetShopBaskets_WithExistingShopBaskets_ReturnsAllShopBaskets()
        {
            var expectedShopBaskets = new[]
            {
                CreateRandomShopBasket(),
                CreateRandomShopBasket(),
                CreateRandomShopBasket(),

            };

            serviceStub.Setup(repo => repo.GetAll()).ReturnsAsync(expectedShopBaskets);

            var controller = new ShopBasketsController(serviceStub.Object, httpContextAccessorStub.Object);

            var shopBaskets = await controller.GetShopBaskets();

            shopBaskets.Should().BeEquivalentTo(expectedShopBaskets, options => options.ComparingByMembers<ShopBasket>());

        }

        [Fact]

        public async Task PostShopBasket_WithShopBasketToCreate_ReturnCreatedShopBasket()
        {
            var shopBasketToCreate = CreateRandomShopBasket();

            var controller = new ShopBasketsController(serviceStub.Object, httpContextAccessorStub.Object);

            var result = await controller.PostShopBasket(shopBasketToCreate);

            var createdShopBasket = (result.Result as CreatedAtActionResult).Value as ShopBasket;
            shopBasketToCreate.Should().BeEquivalentTo(createdShopBasket, options => options.ComparingByMembers<ShopBasketRow>());
            shopBasketToCreate.Total.Should().Be(100);
            shopBasketToCreate.Created.Should().Be(DateTime.Today.AddDays(-1));
            shopBasketToCreate.Updated.Should().Be(DateTime.Today);
            shopBasketToCreate.UserId.Should().Be("1");
        }

        [Fact]

        public async Task PutShopBasket_WithExistingShopBasket_ReturnNoContent()
        {
            ShopBasket existingShopBasket = CreateRandomShopBasket();
            serviceStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(existingShopBasket);

            var shopBasketId = existingShopBasket.Id;
            var shopBasketToUpdate = new ShopBasket()
            {
                Total = 99,
                UserId = "6",
            };
            var controller = new ShopBasketsController(serviceStub.Object, httpContextAccessorStub.Object);

            var result = await controller.PutShopBasket(shopBasketId, shopBasketToUpdate);

            result.Should().BeOfType<NoContentResult>();
        }

        /*[Fact]

        public async Task PutShopBasket_WithUnexistingShopBasket_ReturnsNotFound()
        {
            ShopBasket existingShopBasket = CreateRandomShopBasket();
            serviceStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((ShopBasket)null);

            var shopBasketId = existingShopBasket.Id;
            var shopBasketToUpdate = new ShopBasket()
            {
                Total = 99,
                UserId = "6",
            };
            var controller = new ShopBasketsController(serviceStub.Object, httpContextAccessorStub.Object);

            var result = await controller.PutShopBasket(shopBasketId, shopBasketToUpdate);

            result.Should().BeOfType<NotFoundResult>();
        }*/

        [Fact]
        public async Task DeleteShopBasket_WithExistingShopBasket_ReturnsNoContent()
        {
            ShopBasket existingShopBasket = CreateRandomShopBasket();
            serviceStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(existingShopBasket);
            var controller = new ShopBasketsController(serviceStub.Object, httpContextAccessorStub.Object);

            var result = await controller.DeleteShopBasket(existingShopBasket.Id);

            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]

        public async Task DeleteShopBasket_WithUnExistingShopBasket_ReturnsNotFound()
        {
            ShopBasket existingShopBasket = CreateRandomShopBasket();
            serviceStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((ShopBasket)null);
            var controller = new ShopBasketsController(serviceStub.Object, httpContextAccessorStub.Object);

            var result = await controller.DeleteShopBasket(existingShopBasket.Id);

            result.Should().BeOfType<NotFoundResult>();
        }
        private ShopBasket CreateRandomShopBasket()
        {
            return new()
            {
                Id = rand.Next(1000),
                Created = DateTime.Today.AddDays(-1),
                Updated = DateTime.Today,
                Total = 100,
                UserId = "1"
            };
        }
    }
}
