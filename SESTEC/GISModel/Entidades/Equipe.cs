using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbEquipe")]
    public class Equipe: EntidadeBase
    {
        [Key]
        public string  IDEquipe { get; set; }

        [Display(Name ="Nome da Equipe")]
        public string NomeDaEquipe { get; set; }

        [Display(Name ="Processo")]
        public string Processo { get; set; }

        [Display(Name ="Local de Trabalho")]
        public string LocalTrablho { get; set; }

        [Display(Name = "Resumo da Atividade")]
        public string ResumoAtividade { get; set; }

        [Display(Name ="Departamento")]
        public string Departamento { get; set; }

        [Display(Name = "Empresa")]
        public string Empresa { get; set; }

    }
}
