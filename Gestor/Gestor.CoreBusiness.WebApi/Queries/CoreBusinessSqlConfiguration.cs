using System.ComponentModel.DataAnnotations;

namespace Gestor.CoreBusiness.WebApi.Queries
{
    public class CoreBusinessSqlConfiguration
    {
        [Required]
        public string ConnectionString { get; set; }

        [Required]
        public string DatabaseName { get; set; }
    }
}