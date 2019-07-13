using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("Rel_EquipeAspectoResposta")]
    public class EquipeAspectoResposta:EntidadeBase
    {
        [Key]
        public string IDEquipeAspecto { get; set; }

        public string idEquipe { get; set; }

        public string idAspecto { get; set; }

        public string idPergunta { get; set; }

        public Boolean Sim_Nao { get; set; }

        public virtual Equipe Equipe { get; set; }

        public virtual Aspecto Aspecto { get; set; }

        public virtual Pergunta Pergunta { get; set; }


    }
}
