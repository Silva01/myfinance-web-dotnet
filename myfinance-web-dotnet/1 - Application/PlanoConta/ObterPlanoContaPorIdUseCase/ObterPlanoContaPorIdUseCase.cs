using myfinance_web_netcore.Application.Interfaces;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services.Interfaces;

namespace myfinance_web_netcore.Application.PlanoConta.ObterPlanoContaPorIdUseCase
{
    public class ObterPlanoContaPorIdUseCase : IObterPlanoContaPorIdUseCase
    {
        private readonly IPlanoContaService _planoContaService;

        public ObterPlanoContaPorIdUseCase(IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
        }
        
        public PlanoContaModel GetPlanoConta(int? id)
        {
            if (id != null) {
                return _planoContaService.ObterPlanoContaPorId((int) id);
            }

            return new PlanoContaModel();
            
        }
    }
}