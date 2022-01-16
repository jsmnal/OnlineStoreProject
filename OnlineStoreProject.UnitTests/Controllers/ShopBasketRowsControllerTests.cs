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
    public class ShopBasketRowsControllerTests
    {
        private readonly Mock<IShopBasketRowService> serviceStub = new Mock<IShopBasketRowService>();
        private readonly Mock<IHttpContextAccessor> httpContextAccessorStub = new Mock<IHttpContextAccessor>();
        private readonly Random rand = new();

        [Fact]
        public async Task GetShopBasketRow_WithUnExistingShopBasketRow_ReturnsNotFound()
        {
            serviceStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((ShopBasketRow)null);

            var controller = new ShopBasketRowsController(serviceStub.Object, httpContextAccessorStub.Object);

            var result = await controller.GetShopBasketRow(4);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]

        public async Task GetShopBasketRow_WithExistingShopBasketRow_ReturnExpectedShopBasketRow()
        {
            var expectedShopBasketRow = CreateRandomShopBasketRow();
            serviceStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(expectedShopBasketRow);
            var controller = new ShopBasketRowsController(serviceStub.Object, httpContextAccessorStub.Object);

            var result = await controller.GetShopBasketRow(3);

            Assert.IsType<ShopBasketRow>(result.Value);
            result.Value.Should().BeEquivalentTo(expectedShopBasketRow, options => options.ComparingByMembers<ShopBasketRow>());
        }

        [Fact]

        public async Task GetShopBasketRows_WithExistingShopBasketRows_ReturnsAllShopBasketRows()
        {
            var expectedShopBasketRows = new[]
            {
                CreateRandomShopBasketRow(),
                CreateRandomShopBasketRow(),
                CreateRandomShopBasketRow(),

            };

            serviceStub.Setup(repo => repo.GetAll()).ReturnsAsync(expectedShopBasketRows);

            var controller = new ShopBasketRowsController(serviceStub.Object, httpContextAccessorStub.Object);

            var shopBasketRows = await controller.GetShopBasketRows();

            shopBasketRows.Should().BeEquivalentTo(expectedShopBasketRows, options => options.ComparingByMembers<ShopBasketRow>());

        }

        [Fact]

        public async Task PostShopBasketRow_WithShopBasketRowToCreate_ReturnCreatedShopBasketRow()
        {
            var shopBasketRowToCreate = CreateRandomShopBasketRow();

            var controller = new ShopBasketRowsController(serviceStub.Object, httpContextAccessorStub.Object);

            var result = await controller.PostShopBasketRow(shopBasketRowToCreate);

            var createdShopBasketRow = (result.Result as CreatedAtActionResult).Value as ShopBasketRow;
            shopBasketRowToCreate.Should().BeEquivalentTo(createdShopBasketRow, options => options.ComparingByMembers<ShopBasketRow>());
            shopBasketRowToCreate.Quantity.Should().Be(100);
            shopBasketRowToCreate.ProductId.Should().Be(50);
            shopBasketRowToCreate.ShopBasketId.Should().Be(4);
        }

        [Fact]

        public async Task PutShopBasketRow_WithExistingShopBasketRow_ReturnNoContent()
        {
            ShopBasketRow existingShopBasketRow = CreateRandomShopBasketRow();
            serviceStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(existingShopBasketRow);

            var shopBasketRowId = existingShopBasketRow.Id;
            var shopBasketRowToUpdate = new ShopBasketRow()
            {
                Quantity = 99,
                ProductId = 46,
            };
            var controller = new ShopBasketRowsController(serviceStub.Object, httpContextAccessorStub.Object);

            var result = await controller.PutShopBasketRow(shopBasketRowId, shopBasketRowToUpdate);

            result.Should().BeOfType<NoContentResult>();
        }

        /*[Fact]

        public async Task PutShopBasketRow_WithUnexistingShopBasketRow_ReturnsNotFound()
        {
            ShopBasketRow existingShopBasketRow = CreateRandomShopBasketRow();
            serviceStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((ShopBasketRow)null);

            var shopBasketRowId = existingShopBasketRow.Id;
            var shopBasketRowToUpdate = new ShopBasketRow()
            {
                Quantity = 99,
                ProductId = 46,
            };
            var controller = new ShopBasketRowsController(serviceStub.Object, httpContextAccessorStub.Object);

            var result = await controller.PutShopBasketRow(shopBasketRowId, shopBasketRowToUpdate);

            result.Should().BeOfType<NotFoundResult>();
        }*/

        [Fact]
        public async Task DeleteShopBasketRow_WithExistingShopBasketRow_ReturnsNoContent()
        {
            ShopBasketRow existingShopBasketRow = CreateRandomShopBasketRow();
            serviceStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(existingShopBasketRow);
            var controller = new ShopBasketRowsController(serviceStub.Object, httpContextAccessorStub.Object);

            var result = await controller.DeleteShopBasketRow(existingShopBasketRow.Id);

            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]

        public async Task DeleteShopBasketRow_WithUnExistingShopBasketRow_ReturnsNotFound()
        {
            ShopBasketRow existingShopBasketRow = CreateRandomShopBasketRow();
            serviceStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((ShopBasketRow)null);
            var controller = new ShopBasketRowsController(serviceStub.Object, httpContextAccessorStub.Object);

            var result = await controller.DeleteShopBasketRow(existingShopBasketRow.Id);

            result.Should().BeOfType<NotFoundResult>();
        }
        private ShopBasketRow CreateRandomShopBasketRow()
        {
            return new()
            {
                Id = rand.Next(1000),
                Quantity = 100,
                ProductId = 50,
                ShopBasketId = 4,
            };
        }
    }
}
