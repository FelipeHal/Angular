using System.Collections.Generic;

namespace SmartSchool_WebAPI.BusinessEntities
{
    public class Professor
    {
        public Professor()
        {
            
        }

        public Professor(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}