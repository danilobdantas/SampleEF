using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEF.models
{
    public class IdentidadeSecreta
    {
        public int Id { get; set; }
        public string NomeReal { get; set; }
        public Heroi Heroi { get; set; }
        public int HeroiId { get; set; }
    }
}
