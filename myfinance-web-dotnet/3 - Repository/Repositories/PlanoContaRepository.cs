using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Repository.Interfaces;

namespace myfinance_web_netcore.Repository.Repositories
{
    public class PlanoContaRepository : IPlanoContaRepository
    {

        private readonly MyFinanceDbContext _myFinanceDbContext;

        public PlanoContaRepository(MyFinanceDbContext myFinanceDbContext)
        {
            _myFinanceDbContext = myFinanceDbContext;
        }

        public List<PlanoConta> PlanoContas()
        {
            return _myFinanceDbContext.PlanoConta.ToList();
        }
    }
}