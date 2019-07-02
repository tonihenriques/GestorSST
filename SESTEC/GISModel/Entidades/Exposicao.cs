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
    [Table("tbExposicao")]
    public class Exposicao: EntidadeBase
    {
        
        [Key]
        public string IDExposicao { get; set; }

        public string idAtividadeAlocada { get; set; }

        public string idAlocacao { get; set; }

        public string idTipoDeRisco { get; set; }               

        [Display(Name = "Tempo Estimado Mensal")]
        public string TempoEstimado { get; set; }

        [Display(Name ="Exposição")]
        public EExposicaoInsalubre EExposicaoInsalubre { get; set; }

        [Display(Name = "Exposição ao Calor")]
        public EExposicaoCalor EExposicaoCalor { get; set; }

        [Display(Name = "Exposição ")]
        public EExposicaoSeg EExposicaoSeg { get; set; }

        [Display(Name = "Probabilidade")]
        public EProbabilidadeSeg EProbabilidadeSeg { get; set; }

        [Display(Name = "Severidade")]
        public ESeveridadeSeg ESeveridadeSeg { get; set; }

        public virtual AtividadeAlocada AtividadeAlocada { get; set; }

        public virtual TipoDeRisco TipoDeRisco { get; set; }

        
    }
}
