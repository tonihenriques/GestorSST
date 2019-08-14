using System.ComponentModel.DataAnnotations;

namespace Gestor.RazorPages.RestClients.CoreBusiness.Empregados
{
    public enum StatusEmpregado
    {
        Livre = 0,
        Admitido = 1,
        Alocado = 2,
        Liberado = 3,

        [Display(Name = "Liberado / Alocado")]
        LiberadoAlocado = 4,

        [Display(Name = "Liberado / Irregular")]
        LiberadoIrregular = 5,

        Irregular = 9
    }
}