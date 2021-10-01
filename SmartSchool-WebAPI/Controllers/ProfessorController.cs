using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models.Professores;
using SmartSchool.WebAPI.Services;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService professorService;

        public ProfessorController(IProfessorService professorService)
        {
            this.professorService = professorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(professorService.GetAllProfessores());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByAluno/{alunoId}")]
        public IActionResult GetByAlunoId(int alunoId)
        {
            try
            {
                return Ok(professorService.GetProfessoresByAlunoId(alunoId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpGet("{professorId}")]
        public async Task<IActionResult> GetByProfessorId(int professorId)
        {
            try
            {
                return Ok(await professorService.GetProfessorAsync(professorId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(ProfessorEditModel model)
        {
            try
            {
                return Ok(await professorService.InsertProfessorAsync(model));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{professorId}")]
        public async Task<IActionResult> Put(int professorId, ProfessorEditModel model)
        {
            try
            {
                return Ok(await professorService.UpdateProfessorAsync(model));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete("{professorId}")]
        public async Task<IActionResult> Delete(int professorId)
        {
            try
            {
                return Ok(await professorService.DeleteProfessorAsync(professorId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}