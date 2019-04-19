using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbCNAE")]
    public class CNAE: EntidadeBase
    {
        [Key]
        public string IDCNAE { get; set; }

        [Display(Name ="Código")]
        public string Codigo { get; set; }

        [Display(Name ="Descrição do CNAE")]
        public string DescricaoCNAE { get; set; }

        [Display(Name = "Titulo da Atividade Economica")]
        public string Titulo { get; set; }


    }
}
