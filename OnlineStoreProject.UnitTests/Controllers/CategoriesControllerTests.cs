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
        private readonly Mock<IRepository<Category>> repositoryStub = new Mock<IRepository<Category>>();
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

        [Fact]
        public async Task GetCategories_WithExistingCategories_ReturnsAllCategories()
        {
            // Arrange
            var expectedCategories = new[]
            {
                CreateRandomCategory(),
                CreateRandomCategory(),
                CreateRandomCategory()
            };

            repositoryStub.Setup(repo => repo.GetAll())
                .ReturnsAsync(expectedCategories);

            var controller = new CategoriesController(repositoryStub.Object);

            // Act
            var actualCategories = await controller.GetCategories();

            // Assertion
            actualCategories.Should().BeEquivalentTo(
                expectedCategories,
                options => options.ComparingByMembers<Category>());
        }

        [Fact]
        public async Task PostCategory_WithCategoryToCreate_ReturnCreatedCategory()
        {
            // Arrange
            var categoryToCreate = CreateRandomCategory();

            var controller = new CategoriesController(repositoryStub.Object);

            // Act
            var result = await controller.PostCategory(categoryToCreate);

            // Assert
            var createdCategory = (result.Result as CreatedAtActionResult).Value as Category;
            categoryToCreate.Should().BeEquivalentTo(
                createdCategory,
                options => options.ComparingByMembers<Category>()
                );
            createdCategory.Name.Should().Be("TestCategory");
            createdCategory.Description.Should().Be("Tessting");
        }

        [Fact]
        public async Task PutCategory_WithExistingCategory_ReturnNoContent()
        {
            // Arrenge
            Category existingCategory = CreateRandomCategory();

            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>()))
                .ReturnsAsync(existingCategory);

            var categoryId = existingCategory.Id;
            var categoryToUpdate = new Category()
            {
                Description = "Updated Desc",
                Name = "Updated Name"
            };

            var controller = new CategoriesController(repositoryStub.Object);

            // Act
            var result = await controller.PutCategory(categoryId, categoryToUpdate);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task PutCategory_WithUnexistingCategory_ReturnsNotFound()
        {
            // Arrange
            Category existingCategory = CreateRandomCategory();
            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>()))
                .ReturnsAsync((Category)null);

            var categoryId = existingCategory.Id;
            var categoryToUpdate = new Category()
            {
                Description = "Updated Desc",
                Name = "Updated Name"
            };

            var controller = new CategoriesController(repositoryStub.Object);

            // Act
            var result = await controller.PutCategory(categoryId, categoryToUpdate);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task DeleteCategory_WithExistingItem_ReturnsNoContent()
        {
            // Arrenge
            Category existingCategory = CreateRandomCategory();

            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>()))
                .ReturnsAsync(existingCategory);

            var controller = new CategoriesController(repositoryStub.Object);

            // Act
            var result = await controller.DeleteCategory(existingCategory.Id);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task DeleteCategory_WithUnexistingCategory_ReturnsNotFound()
        {
            // Arrange
            Category existingCategory = CreateRandomCategory();
            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>()))
                .ReturnsAsync((Category)null);

            var controller = new CategoriesController(repositoryStub.Object);

            // Act
            var result = await controller.DeleteCategory(existingCategory.Id);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
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
