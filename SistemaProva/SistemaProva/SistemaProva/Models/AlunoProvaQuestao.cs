using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaProva.Models
{
    public class AlunoProvaQuestao
    {
        public int IdAlunoProvaQuestao { get; set; }
        public int IdProvaQuestao { get; set; }
        public int IdAluno { get; set; }
        public string[] Resposta { get; set; }
        public double Nota { get; set; }
    }
}