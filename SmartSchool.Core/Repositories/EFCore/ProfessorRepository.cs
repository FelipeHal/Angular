using SmartSchool.Core.BusinessEntities;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Core.Repositories.EFCore
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly DataContext context;

        public ProfessorRepository(DataContext context)
        {
            this.context = context;
        }


        public IQueryable<Professores> GetAllProfessores()
        {
            return context.Set<Professores>()
                .OrderBy(c => c.Id);
        }

        public IQueryable<Professores> GetProfessoresByAlunoId(int alunoId)
        {
            return context.Set<Professores>()
                .Where(aluno => aluno.Disciplinas.Any(d => d.AlunosDisciplinas.Any(ad => ad.AlunoId == alunoId)))
                .OrderBy(aluno => aluno.Id);
        }


        public async Task<Professores> GetProfessorByIdAsync(int professorId)
        {
            return await context.Set<Professores>().FindAsync(professorId);
        }


        public async Task InsertProfessorAsync(Professores professor)
        {
            await context.Set<Professores>().AddAsync(professor);
        }

        public async Task UpdateProfessorAsync(Professores professor)
        {
            await Task.Run(() =>
            {
                context.Set<Professores>().Update(professor);
            });
        }

        public async Task DeleteProfessorAsync(int professorId)
        {
            await Task.Run(async () =>
            {
                var professor = await GetProfessorByIdAsync(professorId);

                context.Set<Professores>().Remove(professor);
            });
        }
    }
}