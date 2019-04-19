using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbContrato")]
   public class Contrato: EntidadeBase
    {
        [Key]
        public string IDContrato { get; set; }

        [Display(Name ="Número do Contrato")]
        public string NumeroContrato { get; set; }

        [Display(Name ="Descrição do Contrato")]
        public string DescricaoContrato { get; set; }

        [Display(Name ="Data de Início")]
        public string DataInicio { get; set; }

        [Display(Name ="Data de Término")]
        public string DataFim { get; set; }

        [Display(Name ="Empresa")]
        public string  IdEmpresa { get; set; }


        public virtual Empresa Empresa { get; set; }

        //public virtual ICollection<Alocacao> Alocacao { get; set; }

    }
}
