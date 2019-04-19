using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbAtividade")]
    public class Atividade: EntidadeBase
    {
        [Key]
        public string IDAtividade { get; set; }        
        
        [Display(Name ="Descrição da Atividade")]
        public string Descricao { get; set; }

        [Display(Name = "Função")]
        public string idFuncao { get; set; }

        [Display(Name = "Diretoria")]
        public string idDiretoria { get; set; }

        public virtual Funcao Funcao { get; set; }

        public virtual Diretoria Diretoria { get; set; }



    }
}
