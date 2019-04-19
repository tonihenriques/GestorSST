using GISModel.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbEstabelecimentoAmbiente")]
    public class EstabelecimentoAmbiente: EntidadeBase
    {
        [Key]
        public string IDEstabelecimentoImagens { get; set; }

        [Display(Name ="Resumo do local")]
        public string ResumoDoLocal { get; set; }

        [Display(Name ="Nome da Imagem")]
        public string NomeDaImagem { get; set; }

        [Display(Name ="Imagem")]
        public string Imagem { get; set; }

        [Display(Name ="Estabelecimento")]
        public string IDEstabelecimento { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }
    }
}
