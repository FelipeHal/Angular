using System.Threading.Tasks;
using SmartSchool_WebAPI.BusinessEntities;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //ALUNO
        Task<AlunoModel[]> GetAllAlunosAsync(bool includeProfessor);        
        Task<AlunoModel[]> GetAlunosAsyncByDisciplinaId(int disciplinaId, bool includeDisciplina);
        Task<AlunoModel> GetAlunoAsyncById(int alunoId, bool includeProfessor);
        
        //PROFESSOR
        Task<ProfessorModel[]> GetAllProfessoresAsync(bool includeAluno);
        Task<ProfessorModel> GetProfessorAsyncById(int professorId, bool includeAluno);
        Task<ProfessorModel[]> GetProfessoresAsyncByAlunoId(int alunoId, bool includeDisciplina);
    }
}
