using AutoMapper;

namespace SmartSchool.WebAPI.Models.Professores
{
    [AutoMap(typeof(Core.BusinessEntities.Professores))]
    public class ProfessorListModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}