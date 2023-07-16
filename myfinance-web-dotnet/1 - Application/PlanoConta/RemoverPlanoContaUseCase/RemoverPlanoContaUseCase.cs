

using myfinance_web_netcore.Application.Interfaces;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services.Interfaces;

namespace myfinance_web_netcore.Application.PlanoConta.RemoverPlanoContaUseCase
{
    public class RemoverPlanoContaUseCase : IRemovePlanoContaPorId
    {

        private readonly IPlanoContaService _planoContaService;

        public RemoverPlanoContaUseCase(IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
        }

        public void Excluir(int id)
        {
            _planoContaService.RemoverPorId(id);
        }
    }
}