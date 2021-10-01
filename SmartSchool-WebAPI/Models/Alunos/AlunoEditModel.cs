using AutoMapper;

namespace SmartSchool.WebAPI.Models.Alunos
{
    [AutoMap(typeof(Core.BusinessEntities.Alunos), ReverseMap = true)]
    public class AlunoEditModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
    }
}