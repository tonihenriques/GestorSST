using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbDocAtividade")]
    public class DocAtividade: EntidadeBase
    {

        [Key]
        public string IDDocAtividade { get; set; }

        public string IDUniqueKey { get; set; }

        public string IDDocumentosEmpregado { get; set; }

        public Atividade UniqueKey { get; set; }

        public virtual DocumentosPessoal DocumentosEmpregado { get; set; }

    }
}
