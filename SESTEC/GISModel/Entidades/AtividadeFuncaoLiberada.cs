using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbAtividadeFuncaoLiberada")]
   public class AtividadeFuncaoLiberada:EntidadeBase
    {
        [Key]
        public string IDAtividadeFuncaoLiberada { get; set; }

        public string IDFuncao { get; set; }

        public string IDAtividade { get; set; }

        public string IDAlocacao { get; set; }

        public virtual Funcao Funcao { get; set; }

        public virtual Atividade Atividade { get; set; }

        public virtual Alocacao Alocacao { get; set; }

    }
}
