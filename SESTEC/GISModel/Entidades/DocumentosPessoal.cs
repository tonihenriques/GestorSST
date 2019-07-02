using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbDocumentosPessoal")]
    public class DocumentosPessoal: EntidadeBase
    {
        [Key]
        public string IDDocumentosEmpregado { get; set; }

        [Display(Name ="Nome do Documento")]
        public string NomeDocumento { get; set; }

        [Display(Name ="Descrição")]
        public string DescriçãoDocumento { get; set; }





    }
}
