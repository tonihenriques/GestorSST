using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.DTO.QuestionarioPssicossocial
{
    public class VMRespostas
    {
        // public string Usuario { get; set; }
        public string idPergunta { get; set; }

        public string idEquipe  { get; set; }

        public string idAspectoPergunta { get; set; }

        public string Equipe { get; set; }

        public string Aspecto { get; set; }

        public string Pergunta { get; set; }

        public string Descricao { get; set; }

        public string Sim_Nao { get; set; }
    }
}
