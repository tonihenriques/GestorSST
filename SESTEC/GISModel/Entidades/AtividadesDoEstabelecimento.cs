using GISModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbAtividadesDoEstabelecimento")]
    public class AtividadesDoEstabelecimento: EntidadeBase
    {
        [Key]
        public string IDAtividadesDoEstabelecimento { get; set; }

        [Display(Name ="Ativar")]
        public string Ativo { get; set; }

        //[Display(Name ="Classifique o Risco")]
        //public EClasseDoRisco EClasseDoRisco { get; set; }

        [Display(Name ="Descrição desta Atividade")]
        public string DescricaoDestaAtividade { get; set; }

        //[Display(Name ="Fonte Geradora")]
        //public string FonteGeradora { get; set; }

        [Display(Name ="Nome da Imagem ")]
        public string NomeDaImagem { get; set; }

        [Display(Name ="Imagem")]
        public string Imagem { get; set; }        

        [Display(Name = "Ambientes do Estabelecimento")]
        public string IDEstabelecimentoImagens { get; set; }

        [Display(Name = "Estabelecimento")]
        public string IDEstabelecimento { get; set; }

        //[Display(Name ="Tipo de Risco")]
        //public string IDTipoDeRisco { get; set; }

        [Display(Name = "Possiveis Danos")]
        public string IDPossiveisDanos { get; set; }

        [Display(Name = "Evento Perigoso")]
        public string IDEventoPerigoso { get; set; }

        [Display(Name = "Alocacao")]
        public string IDAlocacao { get; set; }

        //[Display(Name ="Tragetória")]
        //public string Tragetoria { get; set; }


        public virtual EstabelecimentoAmbiente EstabelecimentoImagens { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }

        //public virtual TipoDeRisco TipoDeRisco { get; set; }

        public virtual PossiveisDanos PossiveisDanos { get; set; }

        public virtual EventoPerigoso EventoPerigoso { get; set; }

        //public virtual Alocacao Alocacao { get; set; }

       




    }
}
