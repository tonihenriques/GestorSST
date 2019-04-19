using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbDocsPorAtividade")]
    public class DocsPorAtividade: EntidadeBase
    {
        [Key]
        public string IDDocAtividade { get; set; }

        [Display(Name ="Atividade")]
        public string idAtividade { get; set; }

        [Display(Name = "Documento")]
        public string idDocumentosEmpregado { get; set; }
               

        public virtual DocumentosPessoal DocumentosEmpregado { get; set; }

        public virtual Atividade Atividade { get; set; }


    }
}
