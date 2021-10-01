using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Models.Professores;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Services
{
    public interface IProfessorService
    {
        IQueryable<ProfessorListModel> GetAllProfessores();

        IQueryable<ProfessorListModel> GetProfessoresByAlunoId(int alunoId);

        Task<ProfessorEditModel> GetProfessorAsync(int professorId);

        Task<ProfessorEditModel> InsertProfessorAsync(ProfessorEditModel model);

        Task<ProfessorEditModel> UpdateProfessorAsync(ProfessorEditModel professor);

        Task<ProfessorEditModel> DeleteProfessorAsync(int professorId);
    }
}
