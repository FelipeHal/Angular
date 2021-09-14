namespace SmartSchool_WebAPI.BusinessEntities
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

        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public virtual Disciplina Disciplina { get; set; }
    }
}