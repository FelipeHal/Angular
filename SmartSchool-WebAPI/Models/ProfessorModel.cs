using AutoMapper;
using SmartSchool_WebAPI.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebAPI.Models
{
    [AutoMap(typeof(Professor))]
    public class ProfessorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
