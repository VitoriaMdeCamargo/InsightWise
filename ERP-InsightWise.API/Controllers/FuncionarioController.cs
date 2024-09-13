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
            _funcionarioRepository.Add(funcionario);
            return Created();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Funcionario>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]

        public IActionResult GetAll()
        {
            var users = _funcionarioRepository.GetAll();
            return Ok(users);
        }


        [HttpPatch]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Patch([FromBody] Funcionario funcionario)
        {
            _funcionarioRepository.Update(funcionario);
            return Ok();
        }


        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] Funcionario funcionario)
        {
            _funcionarioRepository.Delete(funcionario);
            return Created();
        }
    }
}
