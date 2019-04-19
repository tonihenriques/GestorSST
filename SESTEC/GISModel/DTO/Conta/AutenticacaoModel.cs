using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.DTO.Conta
{
    [Serializable]
    public class AutenticacaoModel
    {

        [Required(ErrorMessage = "Login é obrigatório")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }


        public string CPF { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

    }
}
