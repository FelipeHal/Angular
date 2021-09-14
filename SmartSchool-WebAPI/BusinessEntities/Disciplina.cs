using System.Collections.Generic;

namespace SmartSchool_WebAPI.BusinessEntities
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

        public int Id { get; set; }
        public string Nome { get; set; }
        public int ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}