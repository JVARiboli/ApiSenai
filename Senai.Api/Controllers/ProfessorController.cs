using Microsoft.AspNetCore.Mvc;
using Senai.Domain.DTos;
using Senai.Domain.Entidades;
using Senai.Service.Interfaces;

namespace Senai.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }
        [HttpPost]
        [Route("Adicionar")]
        public ActionResult Salvar(ProfessorDto model)
        {
            var professor = _professorService.Adicionar(model);

            return Ok(professor);
        }
        [HttpDelete]
        [Route("Deletar")]
        public ActionResult Remover(long id)
        {
            var professor = _professorService.Remover(id);

            return Ok(professor);
        }
        [HttpPatch]
        [Route("Editar")]
        public IActionResult Editar(ProfessorDto model)
        {
            var professor = _professorService.Adicionar(model);
            return Ok(professor);
        }
        [HttpGet]
        [Route("BuscarPorId")]

        public ActionResult BuscarPorId(long id)
        {
            var professor = _professorService.BuscarPorId(id);
            return Ok(professor);
        }


    }
}
