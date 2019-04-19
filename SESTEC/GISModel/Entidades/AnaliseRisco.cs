using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace GISModel.Entidades
{
    [Table("tbAnaliseRisco")]
    public class AnaliseRisco : EntidadeBase
    {

        [Key]
        public string IDAnaliseRisco { get; set; }


        [Display(Name = "Atividade Alocada")]
        public string IDAtividadeAlocada { get; set; }

        [Display(Name = "Alocação")]
        public string IDAlocacao { get; set; }

        [Display(Name = "Atividade")]
        public string IDAtividadesDoEstabelecimento { get; set; }

        [Display(Name = "Eventos Perigosos Adicionais")]
        public string IDEventoPerigoso { get; set; }

        [Display(Name = "Perigo Adicional")]
        public string IDPerigoPotencial { get; set; }

        public bool Conhecimento { get; set; }

        public bool BemEstar { get; set; }

        public virtual AtividadeAlocada AtividadeAlocada { get; set; }

        public virtual Alocacao Alocacao { get; set; }




    }
}
