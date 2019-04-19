using GISModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    public class MedidasDeControleExistentes: EntidadeBase
    {
        [Key]
        public string IDMedidasDeControle { get; set; }

        [Display(Name = "Medida de Controle Existente")]
        public string MedidasExistentes { get; set; }

        [Display(Name ="Classificação do Controle")]
        public EClassificacaoDaMedia EClassificacaoDaMedida { get; set; }

        [Display(Name = "Nome da Imagem")]
        public string NomeDaImagem { get; set; }

        [Display(Name = "Imagem")]
        public string Imagem { get; set; }

        [Display(Name = "Controle do Agente Ambiental")]
        public EControle EControle { get; set; }

        [Display(Name ="Tipo de Risco")]
        public string IDTipoDeRisco { get; set; }

        public virtual TipoDeRisco TipoDeRisco { get; set; }

        //[Display(Name ="Risco do Estabelecimento")]
        //public string IDAtividadesDoEstabelecimento { get; set; }

        //public string IDAtividadeRiscos { get; set; }

        //public virtual AtividadesDoEstabelecimento AtividadesDoEstabelecimento { get; set; }

        //public virtual AtividadeRiscos AtividadeRiscos { get; set; }




    }
}
