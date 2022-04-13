#nullable disable
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieStoreBackend.DataAccess.EFCore;
using MovieStoreBackend.DataAccess.EFCore.Repositories;
using MovieStoreBackend.Services;
using MovieStoreBackend.Services.Infrastructure.Services;
using MovieStoreBackend.Services.Infrastructure.Repositories;
using MovieStoreBackend.WebApiCore.Controllers;
using MovieStoreBackend.DTO;
using MovieStoreBackend.Entities;
using System.Collections.Generic;
using System.IO;

namespace MovieStoreBackend.UnitTesting
{
    public class SaleTesting
    {
        private readonly SalesController _controller;
        private readonly ISaleService _service;
        private readonly ISaleRepository _repository;

        public SaleTesting()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfiguration configuration = builder.Build();
            string connectionString = configuration.GetValue<string>("ConnectionStrings:movie_store_db_connection");
            var optionsBuilder = new DbContextOptionsBuilder<MovieStoreDataContext>();
            optionsBuilder.UseSqlServer(connectionString);
            MovieStoreDataContext context = new MovieStoreDataContext(optionsBuilder.Options);
            _repository = new SaleRepository(context);
            _service = new SaleService(_repository);
            _controller = new SalesController(_service);
        }

        [Fact]
        public async void Get_Ok()
        {
            var result = await _controller.GetAllSales();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Get_Quantity()
        {
            var result = await _controller.GetAllSales();
            Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<Response>(((ObjectResult)result).Value);
            //Assert.True(((List<Sale>)response.Data).Count > 0);
        }
    }
}
