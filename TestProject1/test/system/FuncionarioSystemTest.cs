using System.Net;
using System.Net.Http.Json;
using ERP_InsightWise.Database;
using ERP_InsightWise.Database.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace test.system
{
    public class FuncionarioSystemTest : IClassFixture<WebApplicationFactory<ERP_InsightWise.API.Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<ERP_InsightWise.API.Program> _factory;

        public FuncionarioSystemTest(WebApplicationFactory<ERP_InsightWise.API.Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Configurando o banco de dados em memória para os testes de sistema
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<FIAPDBContext>));

                    if (descriptor != null)
                        services.Remove(descriptor);

                    services.AddDbContext<FIAPDBContext>(options =>
                    {
                        options.UseInMemoryDatabase("TestDB_System");
                    });
                });
            });

            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Funcionario_CRUD_ShouldWorkAsExpected()
        {
            // 1. Criar um novo funcionário (Create)
            var novoFuncionario = new Funcionario
            {
                PrimeiroNome = "Carlos",
                Sobrenome = "Silva",
                Cargo = "Engenheiro",
                Salario = 4000.00m,
                DataNascimento = new DateTime(1990, 4, 23),
                DataContratacao = new DateTime(2022, 1, 10),
                Endereco = "Rua D, 456",
                Telefone = "123456789",
                Email = "carlos.silva@example.com",
                Departamento = "Engenharia",
                Status = "Ativo",
                Genero = "Masculino",
                CargaHoraria = "40h Semanais"
            };

            var createResponse = await _client.PostAsJsonAsync("/api/funcionario", novoFuncionario);
            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            var createdFuncionario = await createResponse.Content.ReadFromJsonAsync<Funcionario>();
            Assert.NotNull(createdFuncionario);
            Assert.Equal("Carlos", createdFuncionario.PrimeiroNome);

            // 2. Obter o funcionário criado (Read)
            var getResponse = await _client.GetAsync($"/api/funcionario/{createdFuncionario.Id}");
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            var fetchedFuncionario = await getResponse.Content.ReadFromJsonAsync<Funcionario>();
            Assert.NotNull(fetchedFuncionario);
            Assert.Equal(createdFuncionario.PrimeiroNome, fetchedFuncionario.PrimeiroNome);

            // 3. Atualizar o funcionário (Update)
            fetchedFuncionario.Cargo = "Senior Engineer";
            fetchedFuncionario.Salario = 4500.00m;

            var updateResponse = await _client.PatchAsJsonAsync($"/api/funcionario/{fetchedFuncionario.Id}", fetchedFuncionario);
            Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);

            // Verificar se o funcionário foi atualizado
            var verifyUpdateResponse = await _client.GetAsync($"/api/funcionario/{fetchedFuncionario.Id}");
            var updatedFuncionario = await verifyUpdateResponse.Content.ReadFromJsonAsync<Funcionario>();
            Assert.Equal("Senior Engineer", updatedFuncionario.Cargo);
            Assert.Equal(4500.00m, updatedFuncionario.Salario);

            // 4. Deletar o funcionário (Delete)
            var deleteResponse = await _client.DeleteAsync($"/api/funcionario/{fetchedFuncionario.Id}");
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

            // Verificar se o funcionário foi realmente deletado
            var verifyDeleteResponse = await _client.GetAsync($"/api/funcionario/{fetchedFuncionario.Id}");
            Assert.Equal(HttpStatusCode.NotFound, verifyDeleteResponse.StatusCode);
        }
    }
}
