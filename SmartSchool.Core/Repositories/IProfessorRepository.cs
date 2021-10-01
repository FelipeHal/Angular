using SmartSchool.Core.BusinessEntities;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Core.Repositories
{
    public interface IProfessorRepository
    {
        IQueryable<Professores> GetAllProfessores();
        IQueryable<Professores> GetProfessoresByAlunoId(int alunoId);
        Task<Professores> GetProfessorByIdAsync(int professorId);
        Task InsertProfessorAsync(Professores professor);
        Task UpdateProfessorAsync(Professores professor);
        Task DeleteProfessorAsync(int professorId);
    }
}