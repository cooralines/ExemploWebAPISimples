using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaProva.Models
{
    public class Prova
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataAplicacao { get; set; }
       
    }
}