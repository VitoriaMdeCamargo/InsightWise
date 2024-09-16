using Microsoft.AspNetCore.Mvc;
using System.Net;
using ERP_InsightWise.Repository.Interface;
using ERP_InsightWise.Database.Models;

namespace ERP_InsightWise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IRepository<Funcionario> _funcionarioRepository;

        public FuncionarioController(IRepository<Funcionario> funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] Funcionario funcionario)
        {
            try
            {
                _funcionarioRepository.Add(funcionario);
                return CreatedAtAction(nameof(GetById), new { id = funcionario.Id }, funcionario);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro ao adicionar o registro.");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Funcionario>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var funcionarios = _funcionarioRepository.GetAll();
                return Ok(funcionarios);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro ao recuperar os registros.");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Funcionario), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                var funcionario = _funcionarioRepository.GetById(id);
                if (funcionario == null)
                {
                    return NotFound($"O registro com o ID {id} não foi encontrado.");
                }

                return Ok(funcionario);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro ao recuperar o registro.");
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Patch(int id, [FromBody] Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingFuncionario = _funcionarioRepository.GetById(id);
                if (existingFuncionario == null)
                {
                    return NotFound($"O registro com o ID {id} não foi encontrado.");
                }

                // Atualize os campos relevantes do funcionário
                existingFuncionario.PrimeiroNome = funcionario.PrimeiroNome;
                existingFuncionario.Sobrenome = funcionario.Sobrenome;
                existingFuncionario.Cargo = funcionario.Cargo;
                existingFuncionario.Salario = funcionario.Salario;
                existingFuncionario.DataNascimento = funcionario.DataNascimento;
                existingFuncionario.DataContratacao = funcionario.DataContratacao;
                existingFuncionario.Endereco = funcionario.Endereco;
                existingFuncionario.Telefone = funcionario.Telefone;
                existingFuncionario.Email = funcionario.Email;
                existingFuncionario.Departamento = funcionario.Departamento;
                existingFuncionario.Status = funcionario.Status;
                existingFuncionario.Genero = funcionario.Genero;
                existingFuncionario.CargaHoraria = funcionario.CargaHoraria;

                _funcionarioRepository.Update(existingFuncionario);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro ao atualizar o registro.");
            }
        }



        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                var funcionario = _funcionarioRepository.GetById(id);
                if (funcionario == null)
                {
                    return NotFound($"O registro com o ID {id} não foi encontrado.");
                }

                _funcionarioRepository.Delete(funcionario);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro ao excluir o registro.");
            }
        }
    }
}