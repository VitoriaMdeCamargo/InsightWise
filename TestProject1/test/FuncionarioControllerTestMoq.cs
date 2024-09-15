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
            var result = _controller.GetById(1);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.Equal(funcionario, okResult.Value);
        }

       

        [Fact]
        public void GetAll_ShouldReturnListOfFuncionarios_WhenFuncionariosExist()
        {
            // Arrange
            var funcionarios = new List<Funcionario>
            {
                new Funcionario { Id = 1, PrimeiroNome = "João", Sobrenome = "Silva" },
                new Funcionario { Id = 2, PrimeiroNome = "Maria", Sobrenome = "Oliveira" }
            };
            _mockRepository.Setup(repo => repo.GetAll()).Returns(funcionarios);

            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.Equal(funcionarios, okResult.Value);
        }

        [Fact]
        public void GetAll_ShouldReturnEmptyList_WhenNoFuncionariosExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetAll()).Returns(new List<Funcionario>());

            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.Empty(okResult.Value as IEnumerable<Funcionario>);
        }

        [Fact]
        public void GetById_ShouldReturnOk_WhenFuncionarioExists()
        {
            // Arrange
            var funcionario = new Funcionario { Id = 1, PrimeiroNome = "João", Sobrenome = "Silva" };
            _mockRepository.Setup(repo => repo.GetById(1)).Returns(funcionario);

            // Act
            var result = _controller.GetById(1);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.Equal(funcionario, okResult.Value);
        }

        [Fact]
        public void GetById_ShouldReturnNotFound_WhenFuncionarioDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetById(2)).Returns((Funcionario)null);

            // Act
            var result = _controller.GetById(2);

            // Assert
            var notFoundResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundResult);
            Assert.Equal((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
            Assert.Equal("O registro com o ID 2 não foi encontrado.", notFoundResult.Value);
        }

        [Fact]
        public void GetById_ShouldReturnInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Throws(new Exception());

            // Act
            var result = _controller.GetById(1);

            // Assert
            var internalServerErrorResult = result as ObjectResult;
            Assert.NotNull(internalServerErrorResult);
            Assert.Equal((int)HttpStatusCode.InternalServerError, internalServerErrorResult.StatusCode);
            Assert.Equal("Ocorreu um erro ao recuperar o registro.", internalServerErrorResult.Value);
        }

    }
}
