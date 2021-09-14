using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SmartSchool_WebAPI.BusinessEntities;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        private readonly IMapper mapper;

        public Repository(DataContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }


        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<AlunoModel[]> GetAllAlunosAsync(bool includeDisciplina = false)
        {
            //IQueryable<Aluno> query = _context.Alunos;

            //// if (includeDisciplina)
            //// {
            ////     query = query.Include(pe => pe.AlunosDisciplinas)
            ////                  .ThenInclude(ad => ad.Disciplina)
            ////                  .ThenInclude(d => d.Professor);
            //// }

            //query = query//.AsNoTracking()
            //             .OrderBy(c => c.Id);

            //return await query.ToArrayAsync();


            return await _context.Alunos
                .OrderBy(c => c.Id)
                .ProjectTo<AlunoModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();

        }
        public async Task<AlunoModel> GetAlunoAsyncById(int alunoId, bool includeDisciplina)
        {
            //IQueryable<Aluno> query = _context.Alunos;

            //// if (includeDisciplina)
            //// {
            ////     query = query.Include(a => a.AlunosDisciplinas)
            ////                  .ThenInclude(ad => ad.Disciplina)
            ////                  .ThenInclude(d => d.Professor);
            //// }

            //query = query//.AsNoTracking()
            //             .OrderBy(aluno => aluno.Id)
            //             .Where(aluno => aluno.Id == alunoId);

            //return await query.FirstOrDefaultAsync();

            return mapper.Map<AlunoModel>(await _context.Alunos.FirstOrDefaultAsync(aluno => aluno.Id == alunoId));
        }
        public async Task<AlunoModel[]> GetAlunosAsyncByDisciplinaId(int disciplinaId, bool includeDisciplina)
        {
            //IQueryable<Aluno> query = _context.Alunos;

            //// if (includeDisciplina)
            //// {
            ////     query = query.Include(p => p.AlunosDisciplinas)
            ////                  .ThenInclude(ad => ad.Disciplina)                             
            ////                  .ThenInclude(d => d.Professor);
            //// }

            //query = query//.AsNoTracking()
            //             .OrderBy(aluno => aluno.Id)
            //             .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));

            //return await query.ToArrayAsync();

            return await _context.Alunos
                .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId))
                .OrderBy(aluno => aluno.Id)
                .ProjectTo<AlunoModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
        }

        public async Task<ProfessorModel[]> GetProfessoresAsyncByAlunoId(int alunoId, bool includeDisciplina)
        {
            //IQueryable<Professor> query = _context.Professores;

            //// if (includeDisciplina)
            //// {
            ////     query = query.Include(p => p.Disciplinas)
            ////     .ThenInclude(ad => ad.AlunosDisciplinas)
            ////     .ThenInclude(d => d.Aluno);
            //// }

            //query = query//.AsNoTracking()
            //             .OrderBy(aluno => aluno.Id)
            //             .Where(aluno => aluno.Disciplinas.Any(d => 
            //                d.AlunosDisciplinas.Any(ad => ad.AlunoId == alunoId)));

            //return await query.ToArrayAsync();

            return await _context.Professores
                .Where(aluno => aluno.Disciplinas.Any(d => d.AlunosDisciplinas.Any(ad => ad.AlunoId == alunoId)))
                .OrderBy(aluno => aluno.Id)
                .ProjectTo<ProfessorModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
        }
        public async Task<ProfessorModel[]> GetAllProfessoresAsync(bool includeDisciplinas = true)
        {
            //IQueryable<Professor> query = _context.Professores;

            //// if (includeDisciplinas)
            //// {
            ////     query = query.Include(c => c.Disciplinas);
            //// }

            //query = query//.AsNoTracking()
            //             .OrderBy(professor => professor.Id);

            //return await query.ToArrayAsync();

            return await _context.Professores
                .OrderBy(c => c.Id)
                .ProjectTo<ProfessorModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
        }
        public async Task<ProfessorModel> GetProfessorAsyncById(int professorId, bool includeDisciplinas = true)
        {
            //IQueryable<Professor> query = _context.Professores;

            //// if (includeDisciplinas)
            //// {
            ////     query = query.Include(pe => pe.Disciplinas);
            //// }

            //query = query//.AsNoTracking()
            //             .OrderBy(professor => professor.Id)
            //             .Where(professor => professor.Id == professorId);

            //return await query.FirstOrDefaultAsync();

            return mapper.Map<ProfessorModel>(await _context.Professores.FirstOrDefaultAsync(professor => professor.Id == professorId));
        }
    }
}
