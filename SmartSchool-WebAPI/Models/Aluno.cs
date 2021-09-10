using System.Collections.Generic;

namespace SmartSchool_WebAPI.Models
{
    public class Aluno
    {
        public Aluno()
        {
        }

        public Aluno(int id, string nome, string sobrenome, string telefone)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
        }

        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Sobrenome { get; set; }
        public virtual string Telefone { get; set; }
        public virtual IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}