using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERP_InsightWise.Database;
using ERP_InsightWise.Database.Models;
using ERP_InsightWise.Repository;
using ERP_InsightWise.API.Controllers;
using System.Net;

namespace ERP_InsightWise.Tests.Controllers
{
    public class FuncionarioControllerTest : IDisposable
    {
        private readonly FuncionarioController _controller;
        private readonly FIAPDBContext _context;

        public FuncionarioControllerTest()
        {
            // Configure the context with an in-memory database for testing purposes
            var options = new DbContextOptionsBuilder<FIAPDBContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            _context = new FIAPDBContext(options);
            _context.Database.EnsureCreated();

            var repository = new Repository<Funcionario>(_context);
            _controller = new FuncionarioController(repository);
        }

        public void Dispose()
        {
            // Cleanup the database after tests
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public void GetById_ShouldReturnNotFound_WhenFuncionarioDoesNotExist()
        {
            // Act
            var result = _controller.GetById(2) as IActionResult;

            // Assert
            var notFoundResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundResult);
            Assert.Equal((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
        }
    }
}
