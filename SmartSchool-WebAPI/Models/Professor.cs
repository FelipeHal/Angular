using System.Collections.Generic;

namespace SmartSchool_WebAPI.Models
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

        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}