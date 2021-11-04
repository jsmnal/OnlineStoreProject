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
    public class CategoriesControllerTests
    {
        private readonly Mock<ICategoryRepository> repositoryStub = new Mock<ICategoryRepository>();
        private readonly Random rand = new();
        [Fact]
        public async Task GetCategory_WithUnexistingCategory_ReturnsNotFound()
        {
            // Arrange
            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>()))
                .ReturnsAsync((Category)null);

            var controller = new CategoriesController(repositoryStub.Object);

            // Act
            var result = await controller.GetCategory(2);

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetCategory_WithExistingCategory_ReturnsExpectedCategory()
        {
            // Arrenge
            var expectedCategory = CreateRandomCategory();

            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>()))
                .ReturnsAsync(expectedCategory);

            var controller = new CategoriesController(repositoryStub.Object);

            // Act
            var result = await controller.GetCategory(1);

            // Assert
            Assert.IsType<Category>(result.Value);
            result.Value.Should().BeEquivalentTo(expectedCategory,
                options => options.ComparingByMembers<Category>());
        }

        private Category CreateRandomCategory()
        {
            return new()
            {
                Id = rand.Next(1000),
                Description = "Tessting",
                Name = "TestCategory",
            };
        }
    }
}
