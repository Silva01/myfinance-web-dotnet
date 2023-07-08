using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    [Route("PlanoConta")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;

        private readonly MyFinanceDbContext _myFinanceDbContext;

        public PlanoContaController(ILogger<PlanoContaController> logger,
                                    MyFinanceDbContext myFinanceDbContext )
        {
            _myFinanceDbContext = myFinanceDbContext;

            _logger = logger;
        }

        public IActionResult Index()
        {

            var listaPlanoContas = _myFinanceDbContext.PlanoConta;

            var listaPlanoContaModel = new List<PlanoContaModel>();

            foreach(var item in listaPlanoContas){
                var planoContaModel = new PlanoContaModel()
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo
                };

                listaPlanoContaModel.Add(planoContaModel);
            }

            ViewBag.listaPlanoConta = listaPlanoContaModel;

            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(int? id)
        {

            var planoConta = new PlanoContaModel();

            if  (id != null){
                var planoContaDomain = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).FirstOrDefault();
                planoConta.Id = planoContaDomain.Id;
                planoConta.Descricao = planoContaDomain.Descricao;
                planoConta.Tipo = planoContaDomain.Tipo;
            }

            return View(planoConta);
        }

        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(PlanoContaModel input)
        {
            var planoConta = new PlanoConta(){
                Id = input.Id,
                Descricao = input.Descricao,
                Tipo = input.Tipo
            };

            if(planoConta.Id == null){
                _myFinanceDbContext.PlanoConta.Add(planoConta);
            }else{
                _myFinanceDbContext.PlanoConta.Attach(planoConta);
                _myFinanceDbContext.Entry(planoConta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            var planoConta = new PlanoConta() { Id = id };
            _myFinanceDbContext.PlanoConta.Remove(planoConta);
            _myFinanceDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}