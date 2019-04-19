using GISModel.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GISModel.Entidades
{
    [Table("tbEstabelecimento")]
    public class Estabelecimento : EntidadeBase
    {
        [Key]
        public string IDEstabelecimento { get; set; }

        [Display(Name ="Tipo de Estabelecimento")]
        public TipoEstabelecimento TipoDeEstabelecimento { get; set; }

        //Inserir aqui um gerdador de codigo que incrementa +1
        [Display(Name = "Código")]
        public string  Codigo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }

       

        [Display(Name = "departamento")]
        public string IDDepartamento { get; set; }

        //[Display(Name = "empresa")]
        //public string IDEmpresa { get; set; }

        
        public virtual Departamento Departamento { get; set; }
                      
        //public virtual Empresa Empresa { get; set; }


        //public virtual ICollection<Alocacao> Alocacao { get; set; }



    }
}
