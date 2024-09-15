using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERP_InsightWise.Database;
using ERP_InsightWise.Database.Models;
using ERP_InsightWise.Repository;
using ERP_InsightWise.API.Controllers;

namespace ERP_InsightWise.Tests.Controllers
{
    public class FuncionarioControllerTest : IDisposable
    {
        private readonly FuncionarioController _controller;
        private readonly FIAPDBContext _context;

        public FuncionarioControllerTest()
        {
            // Configure the context with a real database for testing purposes
            var options = new DbContextOptionsBuilder<FIAPDBContext>()
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
    }
}
