using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
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
    public class ProductsControllerTests
    {
        
        private readonly Mock<IProductRepository> repositoryStub = new Mock<IProductRepository>();
        private readonly Mock<IWebHostEnvironment> hostEnvironmentStub = new Mock<IWebHostEnvironment>();
        private readonly Random rand = new();

        [Fact]
        public async Task GetProduct_WithUnExistingProduct_ReturnsNotFound()
        {
            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((Product)null);
            hostEnvironmentStub.Setup(repo => repo.EnvironmentName).Returns("UnitTestEnvironment");

            var controller = new ProductsController(repositoryStub.Object, hostEnvironmentStub.Object);

            var result = await controller.GetProduct(4);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetProduct_WithExistingProduct_ReturnExpectedProduct()
        {
            var expectedProduct = CreateRandomProduct();
            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(expectedProduct);
            hostEnvironmentStub.Setup(repo => repo.EnvironmentName).Returns("UnitTestEnvironment");
            var controller = new ProductsController(repositoryStub.Object, hostEnvironmentStub.Object);

            var result = await controller.GetProduct(2);

            Assert.IsType<Product>(result.Value);
            result.Value.Should().BeEquivalentTo(expectedProduct, options => options.ComparingByMembers<Product>());
        }

        [Fact]
        public async Task GetProducts_WithExistingProducts_ReturnsAllProducts()
        {
            var expectedProducts = new[]
            {
                CreateRandomProduct(),
                CreateRandomProduct(),
                CreateRandomProduct(),

            };

            repositoryStub.Setup(repo => repo.GetAll()).ReturnsAsync(expectedProducts);
            hostEnvironmentStub.Setup(repo => repo.EnvironmentName).Returns("UnitTestEnvironment");

            var controller = new ProductsController(repositoryStub.Object, hostEnvironmentStub.Object);

            var products = await controller.GetProducts();

            products.Should().BeEquivalentTo(expectedProducts, options => options.ComparingByMembers<Product>());

        }

        [Fact]
        public async Task PostProduct_WithProductToCreate_ReturnCreatedProduct()
        {
            var productToCreate = CreateRandomProduct();

            var controller = new ProductsController(repositoryStub.Object, hostEnvironmentStub.Object);

            var result = await controller.PostProduct(productToCreate);

            var createdProduct = (result.Result as CreatedAtActionResult).Value as Product;
            productToCreate.Should().BeEquivalentTo(createdProduct, options => options.ComparingByMembers<Product>());
            productToCreate.Name.Should().Be("TestProduct");
            productToCreate.Description.Should().Be("Some product");
            productToCreate.StockQuantity.Should().Be(40);
        }

        [Fact]
        public async Task PutProduct_WithExistingProduct_ReturnNoContent()
        {
            Product existingProduct = CreateRandomProduct();
            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(existingProduct);
            hostEnvironmentStub.Setup(repo => repo.EnvironmentName).Returns("UnitTestEnvironment");

            var productId = existingProduct.Id;
            var productToUpdate = new Product()
            {
                Name = "Test",
                Description = "Product",
                StockQuantity = 500,
            };
            var controller = new ProductsController(repositoryStub.Object, hostEnvironmentStub.Object);

            var result = await controller.PutProduct(productId, productToUpdate);

            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task PutProduct_WithUnexistingProduct_ReturnsNotFound()
        {
            Product existingProduct = CreateRandomProduct();
            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((Product)null);
            hostEnvironmentStub.Setup(repo => repo.EnvironmentName).Returns("UnitTestEnvironment");

            var productId = existingProduct.Id;
            var productToUpdate = new Product()
            {
                Name = "Test",
                Description = "Product",
                StockQuantity = 500,
            };
            var controller = new ProductsController(repositoryStub.Object, hostEnvironmentStub.Object);

            var result = await controller.PutProduct(productId, productToUpdate);

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task DeleteProduct_WithExistingProduct_ReturnsNoContent()
        {
            Product existingProduct = CreateRandomProduct();
            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(existingProduct);
            hostEnvironmentStub.Setup(repo => repo.EnvironmentName).Returns("UnitTestEnvironment");

            var controller = new ProductsController(repositoryStub.Object, hostEnvironmentStub.Object);

            var result = await controller.DeleteProduct(existingProduct.Id);

            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task DeleteProduct_WithUnExistingProduct_ReturnsNotFound()
        {
            Product existingProduct = CreateRandomProduct();
            repositoryStub.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((Product)null);
            hostEnvironmentStub.Setup(repo => repo.EnvironmentName).Returns("UnitTestEnvironment");

            var controller = new ProductsController(repositoryStub.Object, hostEnvironmentStub.Object);

            var result = await controller.DeleteProduct(existingProduct.Id);

            result.Should().BeOfType<NotFoundResult>();
        }
        
        [Fact]
        public async Task GetNewest_WithExistingProducts_ReturnsAsManyProductsThatAreGivenInRequest()
        {
            var expectedProducts = new[]
            {
                CreateRandomProduct(),
                CreateRandomProduct(),
                CreateRandomProduct(),

            };

            repositoryStub.Setup(repo => repo.GetNewest(It.IsAny<int>())).ReturnsAsync(expectedProducts);
            hostEnvironmentStub.Setup(repo => repo.EnvironmentName).Returns("UnitTestEnvironment");

            var controller = new ProductsController(repositoryStub.Object, hostEnvironmentStub.Object);

            var products = await controller.GetNewest(3);

            products.Should().BeEquivalentTo(expectedProducts, options => options.ComparingByMembers<Product>());

        }
        
        [Fact]
        public async Task GetPopular_WithExistingProducts_ReturnsAsManyProductsThatAreGivenInRequest()
        {
            var expectedProducts = new[]
            {
                CreateRandomProduct(),
                CreateRandomProduct(),
                CreateRandomProduct(),

            };

            repositoryStub.Setup(repo => repo.GetPopular(It.IsAny<int>())).ReturnsAsync(expectedProducts);
            hostEnvironmentStub.Setup(repo => repo.EnvironmentName).Returns("UnitTestEnvironment");

            var controller = new ProductsController(repositoryStub.Object, hostEnvironmentStub.Object);

            var products = await controller.GetPopular(3);

            products.Should().BeEquivalentTo(expectedProducts, options => options.ComparingByMembers<Product>());

        }
        
        [Fact]
        public async Task GetWithCategory_WithExistingProducts_ReturnsAsManyProductsWhatsFoundWithCategoryName()
        {
            var expectedProducts = new[]
            {
                CreateRandomProduct(),
                CreateRandomProduct(),
                CreateRandomProduct(),

            };

            repositoryStub.Setup(repo => repo.GetWithCategory(It.IsAny<string>())).ReturnsAsync(expectedProducts);
            hostEnvironmentStub.Setup(repo => repo.EnvironmentName).Returns("UnitTestEnvironment");

            var controller = new ProductsController(repositoryStub.Object, hostEnvironmentStub.Object);

            var products = await controller.GetWithCategoryName("Animal pictures");

            products.Should().BeEquivalentTo(expectedProducts, options => options.ComparingByMembers<Product>());

        }
        private Product CreateRandomProduct()
        {
            return new()
            {
                Id = rand.Next(1000),
                Name = "TestProduct",
                Description = "Some product",
                StockQuantity = 40,
            };
        }
    }
}
