using System.ComponentModel.DataAnnotations;

namespace Gestor.RazorPages.RestClients.CoreBusiness
{
    public class CoreBusinessConfiguration
    {
        [Required]
        public string ApiUrl { get; set; }
    }
}