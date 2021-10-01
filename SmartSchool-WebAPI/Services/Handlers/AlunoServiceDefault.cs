using AutoMapper;
using AutoMapper.QueryableExtensions;
using SmartSchool.Core;
using SmartSchool.Core.BusinessEntities;
using SmartSchool.Core.Repositories;
using SmartSchool.WebAPI.Models.Alunos;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Services.Handlers
{
    public class AlunoServiceDefault : IAlunoService
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly IAlunoRepository alunoRepository;

        public AlunoServiceDefault(DataContext context, IMapper mapper, IAlunoRepository alunoRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.alunoRepository = alunoRepository;
        }


        public IQueryable<AlunoListModel> GetAllAlunos()
        {
            return alunoRepository.GetAllAlunos().ProjectTo<AlunoListModel>(mapper.ConfigurationProvider);
        }

        public IQueryable<AlunoListModel> GetAllAlunos(int disciplinaId)
        {
            return alunoRepository.GetAlunosByDisciplina(disciplinaId).ProjectTo<AlunoListModel>(mapper.ConfigurationProvider);
        }


        public async Task<AlunoEditModel> GetAlunoAsync(int alunoId)
        {
            return mapper.Map<AlunoEditModel>(await alunoRepository.GetAlunoByIdAsync(alunoId));
        }


        public async Task<AlunoEditModel> InsertAlunoAsync(AlunoEditModel model)
        {
            var aluno = mapper.Map<Alunos>(model);

            await alunoRepository.InsertAlunoAsync(aluno);
            await context.SaveChangesAsync();

            return await GetAlunoAsync(aluno.Id);
        }

        public async Task<AlunoEditModel> UpdateAlunoAsync(AlunoEditModel model)
        {
            var aluno = mapper.Map<Alunos>(model);

            await alunoRepository.UpdateAlunoAsync(aluno);
            await context.SaveChangesAsync();

            return await GetAlunoAsync(aluno.Id);
        }

        public async Task<AlunoEditModel> DeleteAlunoAsync(int alunoId)
        {
            var aluno = mapper.Map<Alunos>(alunoId);

            await alunoRepository.DeleteAlunoAsync(alunoId);
            await context.SaveChangesAsync();

            return await GetAlunoAsync(aluno.Id);
        }
    }
}