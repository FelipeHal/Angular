using SmartSchool.Core.BusinessEntities;
using SmartSchool.WebAPI.Models.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Services
{
    public interface IAlunoService
    {
        IQueryable<AlunoListModel> GetAllAlunos();

        IQueryable<AlunoListModel> GetAllAlunos(int disciplinaId);

        Task<AlunoEditModel> GetAlunoAsync(int alunoId);

        Task<AlunoEditModel> InsertAlunoAsync(AlunoEditModel model);

        Task<AlunoEditModel> UpdateAlunoAsync(AlunoEditModel aluno);

        Task<AlunoEditModel> DeleteAlunoAsync(int alunoId);
    }
}
