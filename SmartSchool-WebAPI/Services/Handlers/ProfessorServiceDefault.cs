using AutoMapper;
using AutoMapper.QueryableExtensions;
using SmartSchool.Core;
using SmartSchool.Core.BusinessEntities;
using SmartSchool.Core.Repositories;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Models.Professores;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Services.Handlers
{
    public class ProfessorServiceDefault : IProfessorService
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly IProfessorRepository professorRepository;

        public ProfessorServiceDefault(DataContext context, IMapper mapper, IProfessorRepository professorRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.professorRepository = professorRepository;
        }

        public IQueryable<ProfessorListModel> GetAllProfessores()
        {
            return professorRepository.GetAllProfessores().ProjectTo<ProfessorListModel>(mapper.ConfigurationProvider);
        }


        public IQueryable<ProfessorListModel> GetProfessoresByAlunoId(int alunoId)
        {
            return professorRepository.GetProfessoresByAlunoId(alunoId).ProjectTo<ProfessorListModel>(mapper.ConfigurationProvider);
        }

        public async Task<ProfessorEditModel> GetProfessorAsync(int professorId)
        {
            return mapper.Map<ProfessorEditModel>(await professorRepository.GetProfessorByIdAsync(professorId));
        }

        public async Task<ProfessorEditModel> InsertProfessorAsync(ProfessorEditModel model)
        {
            var professor = mapper.Map<Professores>(model);

            await professorRepository.InsertProfessorAsync(professor);
            await context.SaveChangesAsync();

            return await GetProfessorAsync(professor.Id);
        }

        public async Task<ProfessorEditModel> UpdateProfessorAsync(ProfessorEditModel model)
        {
            var professor = mapper.Map<Professores>(model);

            await professorRepository.UpdateProfessorAsync(professor);
            await context.SaveChangesAsync();

            return await GetProfessorAsync(professor.Id);
        }
        public async Task<ProfessorEditModel> DeleteProfessorAsync(int professorId)
        {
            var professor = mapper.Map<Professores>(professorId);

            await professorRepository.DeleteProfessorAsync(professorId);
            await context.SaveChangesAsync();

            return await GetProfessorAsync(professor.Id);
        }
    }
}
