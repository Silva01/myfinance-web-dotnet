using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services.Interfaces
{
    public interface IPlanoContaService
    {
        List<PlanoContaModel> ListaPlanoContaModel();
        void CadastrarPlanoConta(PlanoContaModel input);
        PlanoContaModel ObterPlanoContaPorId(int Id);
        void RemoverPorId(int id);
    }
}