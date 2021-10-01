using SmartSchool.Core.BusinessEntities;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Core.Repositories.EFCore
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly DataContext context;

        public AlunoRepository(DataContext context)
        {
            this.context = context;
        }


        public IQueryable<Alunos> GetAllAlunos()
        {
            return context.Set<Alunos>()
                .OrderBy(c => c.Id);
        }

        public IQueryable<Alunos> GetAlunosByDisciplina(int disciplinaId)
        {
            return context.Set<Alunos>()
                .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId))
                .OrderBy(aluno => aluno.Id);
        }


        public async Task<Alunos> GetAlunoByIdAsync(int alunoId)
        {
            return await context.Set<Alunos>().FindAsync(alunoId);
        }


        public async Task InsertAlunoAsync(Alunos aluno)
        {
            await context.Set<Alunos>().AddAsync(aluno);
        }

        public async Task UpdateAlunoAsync(Alunos aluno)
        {
            await Task.Run(() =>
            {
                context.Set<Alunos>().Update(aluno);
            });
        }

        public async Task DeleteAlunoAsync(int alunoId)
        {
            await Task.Run(async () =>
            {
                var aluno = await GetAlunoByIdAsync(alunoId);

                context.Set<Alunos>().Remove(aluno);
            });
        }
    }
}