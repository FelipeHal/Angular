using System.Collections.Generic;

namespace SmartSchool_WebAPI.Models
{
    public class Disciplina
    {
        public Disciplina()
        {
        }

        public Disciplina(int id, string nome, int professorId)
        {
            Id = id;
            Nome = nome;
            ProfessorId = professorId;
        }

        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual int ProfessorId { get; set; }
        public virtual string Professor{ get; set; }
        public virtual IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}