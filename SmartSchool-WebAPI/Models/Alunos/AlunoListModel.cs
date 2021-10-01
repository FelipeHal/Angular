using AutoMapper;

namespace SmartSchool.WebAPI.Models.Alunos
{
    [AutoMap(typeof(Core.BusinessEntities.Alunos))]
    public class AlunoListModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
    }
}