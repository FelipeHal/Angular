using SmartSchool.Core.BusinessEntities;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Core.Repositories
{
    public interface IAlunoRepository
    {
        IQueryable<Alunos> GetAllAlunos();
        IQueryable<Alunos> GetAlunosByDisciplina(int disciplinaId);

        Task<Alunos> GetAlunoByIdAsync(int alunoId);

        Task InsertAlunoAsync(Alunos aluno);
        Task UpdateAlunoAsync(Alunos aluno);
        Task DeleteAlunoAsync(int alunoId);
    }
}