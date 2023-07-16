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

        public void CadastrarPlanoConta(PlanoConta planoConta)
        {
            if(planoConta.Id == null){
                _myFinanceDbContext.PlanoConta.Add(planoConta);
            }else{
                _myFinanceDbContext.PlanoConta.Attach(planoConta);
                _myFinanceDbContext.Entry(planoConta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();
        }

        public List<PlanoConta> PlanoContas()
        {
            return _myFinanceDbContext.PlanoConta.ToList();
        }
    }
}