using Furiza.AspNetCore.ExceptionHandling;

namespace Gestor.CoreBusiness.WebApi.Exceptions
{
    public class CoreBusinessResourceNotFoundExceptionItem : ResourceNotFoundExceptionItem
    {
        public static CoreBusinessResourceNotFoundExceptionItem Empregado => new CoreBusinessResourceNotFoundExceptionItem("Empregado", "Empregado não encontrado.");

        private CoreBusinessResourceNotFoundExceptionItem(string key, string message) : base(key, message)
        {
        }
    }
}