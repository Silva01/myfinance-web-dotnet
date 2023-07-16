

namespace myfinance_web_netcore.Application.Interfaces
{
    public interface IObterUseCase<TEntity> where TEntity: class
    {
        List<TEntity> GetListaPlanoContaModel();
    }
}