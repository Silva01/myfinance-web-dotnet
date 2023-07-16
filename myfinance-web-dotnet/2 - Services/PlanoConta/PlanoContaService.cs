using myfinance_web_netcore.Models;
using myfinance_web_netcore.Repository.Interfaces;
using myfinance_web_netcore.Services.Interfaces;

namespace myfinance_web_netcore.Services.PlanoConta
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly IPlanoContaRepository _planoContaRepository;

        public PlanoContaService(IPlanoContaRepository planoContaRepository)
        {
            _planoContaRepository = planoContaRepository;
        }

        public List<PlanoContaModel> ListaPlanoContaModel()
        {
            var lista = new List<PlanoContaModel>();

            foreach(var item in _planoContaRepository.PlanoContas())
            {
                var planoContaModel = new PlanoContaModel(){
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo
                };

                lista.Add(planoContaModel);
            }

            return lista;
        }
    }
}