using Moq;
using ERP_InsightWise.API.Controllers;
using ERP_InsightWise.Database.Models;
using ERP_InsightWise.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ERP_InsightWise.Tests.Controllers
{
    public class FuncionarioControllerTestMoq
    {
        private readonly FuncionarioController _controller;
        private readonly Mock<IRepository<Funcionario>> _mockRepository;

        public FuncionarioControllerTestMoq()
        {
            _mockRepository = new Mock<IRepository<Funcionario>>();
            _controller = new FuncionarioController(_mockRepository.Object);
        }

        [Fact]
        public void GetById_ShouldReturnFuncionario_WhenFuncionarioExists()
        {
            // Arrange
            var funcionario = new Funcionario { Id = 1, PrimeiroNome = "João", Sobrenome = "Silva" };
            _mockRepository.Setup(repo => repo.GetById(1)).Returns(funcionario);

            // Act
            var result = _controller.GetById(1) as IActionResult;

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.Equal(funcionario, okResult.Value);
        }
    }
}
