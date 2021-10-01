using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models.Alunos;
using SmartSchool.WebAPI.Services;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            this.alunoService = alunoService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(alunoService.GetAllAlunos());
            }
            
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByDisciplina/{disciplinaId}")]
        public IActionResult GetByDisciplinaId(int disciplinaId)
        {
            try
            {
                return Ok(alunoService.GetAllAlunos(disciplinaId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


        [HttpGet("{alunoId}")]
        public async Task<IActionResult> GetByAlunoId(int alunoId)
        {
            try
            {
                return Ok(await alunoService.GetAlunoAsync(alunoId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(AlunoEditModel model)
        {
            try
            {
                return Ok(await alunoService.InsertAlunoAsync(model));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{alunoId}")]
        public async Task<IActionResult> Put(int alunoId, AlunoEditModel model)
        {
            try
            {
                return Ok(await alunoService.UpdateAlunoAsync(model));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        

        [HttpDelete("{alunoId}")]
        public async Task<IActionResult> Delete(int alunoId)
        {
            try
            {
                return Ok(await alunoService.DeleteAlunoAsync(alunoId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}