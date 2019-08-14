namespace Gestor.RazorPages.RestClients.CoreBusiness.Empregados
{
    public class EmpregadosGetMany
    {
        public StatusEmpregado? Status { get; set; }
        public int? Quantidade { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
    }
}