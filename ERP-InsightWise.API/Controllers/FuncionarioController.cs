using Microsoft.AspNetCore.Mvc;
using System.Net;
using ERP_InsightWise.Repository.Interface;
using ERP_InsightWise.Database.Models;

namespace ERP_InsightWise.API.Controllers
{
    [Route("[controller]")]
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

        [HttpPatch]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Patch([FromBody] Funcionario funcionario)
        {
            try
            {
                var existingFuncionario = _funcionarioRepository.GetById(funcionario.Id);
                if (existingFuncionario == null)
                {
                    return NotFound($"O registro com o ID {funcionario.Id} não foi encontrado.");
                }

                _funcionarioRepository.Update(funcionario);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro ao atualizar o registro.");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
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
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro ao excluir o registro.");
            }
        }
    }
}