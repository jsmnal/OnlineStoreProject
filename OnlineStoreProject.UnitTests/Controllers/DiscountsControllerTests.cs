using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineStoreProject.Controllers;
using OnlineStoreProject.Data.DAL;
using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineStoreProject.UnitTests.Controllers
{
    public class DiscountsControllerTests
    {
        private readonly Mock<IRepository<Discount>> repositoryStub = new Mock<IRepository<Discount>>();
        private readonly Random rand = new();

        [Fact]
        public async Task GetDiscount_WithUnExistingDiscount_ReturnsNotFound()
        {
            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((Discount)null);

            var controller = new DiscountsController(repositoryStub.Object);

            var result = await controller.GetDiscount(3);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]

        public async Task GetDiscount_WithExistingDiscount_ReturnExpectedDiscount()
        {
            var expectedDiscount = CreateRandomDiscount();
            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(expectedDiscount);
            var controller = new DiscountsController(repositoryStub.Object);

            var result = await controller.GetDiscount(3);

            Assert.IsType<Discount>(result.Value);
            result.Value.Should().BeEquivalentTo(expectedDiscount, options => options.ComparingByMembers<Discount>());
        }

        [Fact]

        public async Task GetDiscounts_WithExistingDiscounts_ReturnsAllDiscounts()
        {
            var expectedDiscounts = new[]
            {
                CreateRandomDiscount(),
                CreateRandomDiscount(),
                CreateRandomDiscount(),
                
            };

            repositoryStub.Setup(repo => repo.GetAll()).ReturnsAsync(expectedDiscounts);

            var controller = new DiscountsController(repositoryStub.Object);

            var discounts = await controller.GetDiscounts();

            discounts.Should().BeEquivalentTo(expectedDiscounts, options => options.ComparingByMembers<Discount>());

        }

        [Fact]

        public async Task PostDiscount_WithDiscountToCreate_ReturnCreatedDiscount()
        {
            var discountToCreate = CreateRandomDiscount();

            var controller = new DiscountsController(repositoryStub.Object);

            var result = await controller.PostDiscount(discountToCreate);

            var createdDiscount = (result.Result as CreatedAtActionResult).Value as Discount;
            discountToCreate.Should().BeEquivalentTo(createdDiscount, options => options.ComparingByMembers<Discount>());
            discountToCreate.Name.Should().Be("TestDiscount");
            discountToCreate.Description.Should().Be("Discount for testing");
            discountToCreate.DiscountPercentage.Should().Be(20);
            discountToCreate.ActivityState.Should().Be(false);
        }

        [Fact]

        public async Task PutDiscount_WithExistingDiscount_ReturnNoContent()
        {
            Discount existingDiscount = CreateRandomDiscount();
            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(existingDiscount);

            var discountId = existingDiscount.Id;
            var discountToUpdate = new Discount()
            {
                Name = "UpdatedTestDiscount",
                Description = "Updated description",
                ActivityState = true
            };
            var controller = new DiscountsController(repositoryStub.Object);

            var result = await controller.PutDiscount(discountId, discountToUpdate);

            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]

        public async Task PutDiscount_WithUnexistingDiscount_ReturnsNotFound()
        {
            Discount existingDiscount = CreateRandomDiscount();
            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((Discount)null);

            var discountId = existingDiscount.Id;
            var discountToUpdate = new Discount()
            {
                Name = "UpdatedTestDiscount",
                Description = "Updated description",
                ActivityState = true
            };
            var controller = new DiscountsController(repositoryStub.Object);

            var result = await controller.PutDiscount(discountId, discountToUpdate);

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task DeleteDiscount_WithExistingDiscount_ReturnsNoContent()
        {
            Discount existingDiscount = CreateRandomDiscount();
            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(existingDiscount);
            var controller = new DiscountsController(repositoryStub.Object);

            var result = await controller.DeleteDiscount(existingDiscount.Id);

            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]

        public async Task DeleteDiscount_WithUnExistingDiscount_ReturnsNotFound()
        {
            Discount existingDiscount = CreateRandomDiscount();
            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((Discount)null);
            var controller = new DiscountsController(repositoryStub.Object);

            var result = await controller.DeleteDiscount(existingDiscount.Id);

            result.Should().BeOfType<NotFoundResult>();
        }
        private Discount CreateRandomDiscount()
        {
            return new()
            {
                Id = rand.Next(1000),
                Name = "TestDiscount",
                Description = "Discount for testing",
                DiscountPercentage = 20,
                ActivityState = false,
            };
        }
    }
}
