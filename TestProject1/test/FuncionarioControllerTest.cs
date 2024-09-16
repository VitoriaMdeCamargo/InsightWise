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

            // Seed the database with initial data
            SeedDatabase();
        }

        public void Dispose()
        {
            // Cleanup the database after tests
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        private void SeedDatabase()
        {
            var funcionario1 = new Funcionario
            {
                Id = 1,
                PrimeiroNome = "João",
                Sobrenome = "Silva",
                Cargo = "Analista",
                Salario = 3000.00m,
                DataNascimento = new DateTime(1990, 5, 1),
                DataContratacao = new DateTime(2015, 6, 1),
                Endereco = "Rua A, 123",
                Telefone = "1234567890",
                Email = "joao.silva@example.com",
                Departamento = "TI",
                Status = "Ativo",
                Genero = "Masculino",
                CargaHoraria = "40h Semanais"
            };

            var funcionario2 = new Funcionario
            {
                Id = 2,
                PrimeiroNome = "Maria",
                Sobrenome = "Oliveira",
                Cargo = "Desenvolvedora",
                Salario = 3500.00m,
                DataNascimento = new DateTime(1988, 7, 15),
                DataContratacao = new DateTime(2017, 8, 1),
                Endereco = "Rua B, 456",
                Telefone = "0987654321",
                Email = "maria.oliveira@example.com",
                Departamento = "Desenvolvimento",
                Status = "Ativo",
                Genero = "Feminino",
                CargaHoraria = "40h Semanais"
            };

            _context.Funcionarios.AddRange(funcionario1, funcionario2);
            _context.SaveChanges();
        }

        [Fact]
        public void GetById_ShouldReturnFuncionario_WhenFuncionarioExists()
        {
            // Act
            var result = _controller.GetById(1);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);

            var returnedFuncionario = okResult.Value as Funcionario;
            Assert.NotNull(returnedFuncionario);
            Assert.Equal(1, returnedFuncionario.Id);
            Assert.Equal("João", returnedFuncionario.PrimeiroNome);
            Assert.Equal("Silva", returnedFuncionario.Sobrenome);
        }

        [Fact]
        public void GetById_ShouldReturnNotFound_WhenFuncionarioDoesNotExist()
        {
            // Act
            var result = _controller.GetById(999);

            // Assert
            var notFoundResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundResult);
            Assert.Equal((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
        }

        [Fact]
        public void CreateFuncionario_ShouldReturnCreated_WhenFuncionarioIsCreated()
        {
            // Arrange
            var newFuncionario = new Funcionario
            {
                PrimeiroNome = "Ana",
                Sobrenome = "Pereira",
                Cargo = "Tester",
                Salario = 2800.00m,
                DataNascimento = new DateTime(1992, 3, 10),
                DataContratacao = new DateTime(2021, 9, 1),
                Endereco = "Rua C, 789",
                Telefone = "1112233445",
                Email = "ana.pereira@example.com",
                Departamento = "Qualidade",
                Status = "Ativo",
                Genero = "Feminino",
                CargaHoraria = "40h Semanais"
            };

            // Act
            var result = _controller.Post(newFuncionario);

            // Assert
            var createdResult = result as CreatedAtActionResult;
            Assert.NotNull(createdResult);
            Assert.Equal((int)HttpStatusCode.Created, createdResult.StatusCode);

            var addedFuncionario = _context.Funcionarios.FirstOrDefault(f => f.Email == "ana.pereira@example.com");
            Assert.NotNull(addedFuncionario);
            Assert.Equal(newFuncionario.PrimeiroNome, addedFuncionario.PrimeiroNome);
        }

        [Fact]
        public void DeleteFuncionario_ShouldReturnOk_WhenFuncionarioIsDeleted()
        {
            // Act
            var result = _controller.Delete(2);

            // Assert
            var okResult = result as NoContentResult;
            Assert.NotNull(okResult);
            Assert.Equal((int)HttpStatusCode.NoContent, okResult.StatusCode);

            // Verifica se o funcionário foi removido do banco de dados
            var deletedFuncionario = _context.Funcionarios.Find(2);
            Assert.Null(deletedFuncionario);

        }

        [Fact]
        public void PatchFuncionario_ShouldReturnOk_WhenFuncionarioIsUpdated()
        {
            // Arrange
            var updatedFuncionario = new Funcionario
            {
                PrimeiroNome = "João Atualizado",
                Sobrenome = "Silva",
                Cargo = "Analista",
                Salario = 3200.00m,
                DataNascimento = new DateTime(1990, 5, 1),
                DataContratacao = new DateTime(2015, 6, 1),
                Endereco = "Rua A, 123",
                Telefone = "1234567890",
                Email = "joao.silva@example.com",
                Departamento = "TI",
                Status = "Ativo",
                Genero = "Masculino",
                CargaHoraria = "40h Semanais"
            };

            // Act
            var result = _controller.Patch(1, updatedFuncionario);

            // Assert
            Assert.NotNull(result);
            var okResult = result as OkResult;
            Assert.NotNull(okResult); 
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);

            // Verifica se o funcionário foi atualizado no banco de dados
            var funcionario = _context.Funcionarios.Find(1);
            Assert.NotNull(funcionario);
            Assert.Equal("João Atualizado", funcionario.PrimeiroNome);
            Assert.Equal(3200.00m, funcionario.Salario);
        }



        [Fact]
        public void PatchFuncionario_ShouldReturnNotFound_WhenFuncionarioDoesNotExist()
        {
            // Arrange
            var funcionarioToUpdate = new Funcionario
            {
                Id = 999, // ID que não existe
                PrimeiroNome = "Não Existe",
                Sobrenome = "Aqui",
                Cargo = "Teste",
                Salario = 0.00m,
                DataNascimento = new DateTime(2000, 1, 1),
                DataContratacao = new DateTime(2020, 1, 1),
                Endereco = "Desconhecido",
                Telefone = "0000000000",
                Email = "nao.existe@example.com",
                Departamento = "N/A",
                Status = "Desconhecido",
                Genero = "Desconhecido",
                CargaHoraria = "N/A"
            };

            // Act
            var result = _controller.Patch(99,funcionarioToUpdate);

            // Assert
            var notFoundResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundResult);
            Assert.Equal((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
        }
    }
}
