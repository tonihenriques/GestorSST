using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    public class EntidadeBase
    {

        public string UsuarioInclusao { get; set; }

        public DateTime DataInclusao { get; set; }

        public string UsuarioExclusao { get; set; }
                
        public DateTime DataExclusao { get; set; }

    }
}
