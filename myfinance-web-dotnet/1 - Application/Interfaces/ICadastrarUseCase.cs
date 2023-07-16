
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Application.Interfaces
{
    public interface ICadastrarUseCase<TEntity> where TEntity: class 
    {
        void CadastrarPlanoConta(TEntity input);
    }
}