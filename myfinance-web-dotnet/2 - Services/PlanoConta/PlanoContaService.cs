using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Repository.Interfaces;
using myfinance_web_netcore.Services.Interfaces;

namespace myfinance_web_netcore.Services.PlanoContaService
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly IPlanoContaRepository _planoContaRepository;

        public PlanoContaService(IPlanoContaRepository planoContaRepository)
        {
            _planoContaRepository = planoContaRepository;
        }

        public void CadastrarPlanoConta(PlanoContaModel input)
        {
            var planoConta = new PlanoConta(){
                Id = input.Id,
                Descricao = input.Descricao,
                Tipo = input.Tipo
            };

            _planoContaRepository.Cadastrar(planoConta);
        }

        public List<PlanoContaModel> ListaPlanoContaModel()
        {
            var lista = new List<PlanoContaModel>();

            foreach(var item in _planoContaRepository.ListarRegistros())
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

        public PlanoContaModel ObterPlanoContaPorId(int Id)
        {
            var planoConta = _planoContaRepository.RetornarRegistro(Id);
            var planoContaModel = new PlanoContaModel() {
                Id = planoConta.Id,
                Descricao = planoConta.Descricao,
                Tipo = planoConta.Tipo
            };

            return planoContaModel;
        }

        public void RemoverPorId(int id)
        {
            _planoContaRepository.Excluir(id);
        }
    }
}