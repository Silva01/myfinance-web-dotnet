
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Application.Interfaces
{
    public interface IObterPorIdUseCase<TEntity> where TEntity: class 
    {
        TEntity GetPlanoConta(int? id);
    }
}