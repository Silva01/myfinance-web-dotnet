using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    [Route("Transacao")]
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;

        private readonly MyFinanceDbContext _myFinanceDbContext;

        public TransacaoController(ILogger<TransacaoController> logger,
                                    MyFinanceDbContext myFinanceDbContext )
        {
            _myFinanceDbContext = myFinanceDbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {

            var transacoes = _myFinanceDbContext.Transacao.Include(x => x.PlanoConta);

            var listaTransacoesModel = new List<TransacaoModel>();

            foreach(var item in transacoes){

                var planoContaModel = new PlanoContaModel() 
                {
                    Id = item.PlanoConta.Id,
                    Descricao = item.PlanoConta.Descricao,
                    Tipo = item.PlanoConta.Tipo
                };

                var transacaoModel = new TransacaoModel()
                {
                    Id = item.Id,
                    Data = item.Data,
                    Historico = item.Historico,
                    PlanoContaId = item.PlanoContaId,
                    Valor = item.Valor,
                    ItemPlanoConta = planoContaModel 
                };

                listaTransacoesModel.Add(transacaoModel);
            }

            ViewBag.Transacoes = listaTransacoesModel;

            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(int? id)
        {

            var itensPlanoConta = _myFinanceDbContext.PlanoConta;
            var transacaoModel = new TransacaoModel();

            List<SelectListItem> itensPlano = new();

            foreach(var item in itensPlanoConta) {
                itensPlano.Add(new SelectListItem() { Text = item.Descricao, Value = item.Id.ToString() });
            }

            transacaoModel.PlanoContas =  itensPlano;

            if(id != null) {
                var transacao = _myFinanceDbContext.Transacao.Where(x => x.Id == id).FirstOrDefault();
                transacaoModel.Data = transacao.Data;
                transacaoModel.Historico = transacao.Historico;
                transacaoModel.Valor = transacao.Valor;
                transacaoModel.PlanoContaId = transacao.PlanoContaId;
            }

            return View(transacaoModel);
        }

        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(TransacaoModel input)
        {
            var transacao = new Transacao(){
                Id = input.Id,
                Data = input.Data,
                Valor = input.Valor,
                Historico = input.Historico,
                PlanoContaId = input.PlanoContaId
            };

            if(transacao.Id == null){
                _myFinanceDbContext.Transacao.Add(transacao);
            }else{
                _myFinanceDbContext.Transacao.Attach(transacao);
                _myFinanceDbContext.Entry(transacao).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            var planoConta = new Transacao() { Id = id };
            _myFinanceDbContext.Transacao.Remove(planoConta);
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