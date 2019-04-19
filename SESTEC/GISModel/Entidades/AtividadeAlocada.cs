using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbAtividadeAlocada")]
    public class AtividadeAlocada:EntidadeBase
    {

        [Key]
        public string IDAtividadeAlocada { get; set; }
        
        public string idAtividadesDoEstabelecimento { get; set; }
        
        public string  idAlocacao { get; set; }

        public virtual AtividadesDoEstabelecimento AtividadesDoEstabelecimento { get; set; }

        public virtual Alocacao Alocacao { get; set; }

        

    }
}
