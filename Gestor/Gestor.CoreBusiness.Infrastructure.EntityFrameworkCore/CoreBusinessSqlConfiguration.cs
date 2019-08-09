using System.ComponentModel.DataAnnotations;

namespace Gestor.CoreBusiness.Infrastructure.EntityFrameworkCore
{
    public class CoreBusinessSqlConfiguration
    {
        [Required]
        public string ConnectionString { get; set; }

        public bool EnableMigrations { get; set; } = false;
    }
}