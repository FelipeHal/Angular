namespace SmartSchool_WebAPI.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina()
        {
        }

        public AlunoDisciplina(int alunoId, int disciplinaId)
        {
            AlunoId = alunoId;
            DisciplinaId = disciplinaId;
        }

        public virtual int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual int DisciplinaId { get; set; }
        public virtual Disciplina Disciplina { get; set; }
    }
}