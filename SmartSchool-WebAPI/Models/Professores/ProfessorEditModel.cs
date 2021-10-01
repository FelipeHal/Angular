using AutoMapper;

namespace SmartSchool.WebAPI.Models.Professores
{
    [AutoMap(typeof(Core.BusinessEntities.Professores), ReverseMap = true)]
    public class ProfessorEditModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}