using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("Rel_AtivEstabTipoRisco")]
    public class Rel_AtivEstabTipoRisco: EntidadeBase
    {
        [Key]
        public string IDAtivEstabTipoRisco { get; set; }

        //public string idAtividadeEstabelecimento { get; set; }

        //public string  idTipoDeRisco { get; set; }


        //public virtual AtividadesDoEstabelecimento AtividadesDoEstabelecimento { get; set; }

        //public virtual TipoDeRisco TipoDeRisco { get; set; }


    }
}
