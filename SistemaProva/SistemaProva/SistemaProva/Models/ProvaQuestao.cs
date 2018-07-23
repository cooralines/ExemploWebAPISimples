using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaProva.Models
{
    public class ProvaQuestao
    {
        public int IdProvaQuestao { get; set; }
        public int IdProva { get; set; }
        public int IdQuestao { get; set; }
        public double Valor { get; set; }
        
    }
}