using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Application.Interfaces;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    [Route("PlanoConta")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;

        private readonly IObterPlanoContaUseCase _obterPlanoContaUseCase;

        private readonly IObterPlanoContaPorIdUseCase _obterPlanoContaPorIdUseCase;

        private readonly ICadastrarPlanoContaUseCase _cadastrarPlanoContaUseCase;

        private readonly IRemovePlanoContaPorId _removePlanoConta;

        public PlanoContaController(ILogger<PlanoContaController> logger,
                                    IObterPlanoContaUseCase obterPlanoContaUseCase,
                                    ICadastrarPlanoContaUseCase cadastrarPlanoContaUseCase,
                                    IObterPlanoContaPorIdUseCase obterPlanoContaPorIdUseCase,
                                    IRemovePlanoContaPorId removePlanoConta)
        {

            _logger = logger;

            _obterPlanoContaUseCase = obterPlanoContaUseCase;
            _cadastrarPlanoContaUseCase = cadastrarPlanoContaUseCase;
            _obterPlanoContaPorIdUseCase = obterPlanoContaPorIdUseCase;
            _removePlanoConta = removePlanoConta;
        }

        public IActionResult Index()
        {
            ViewBag.listaPlanoConta = _obterPlanoContaUseCase.GetListaPlanoContaModel();
            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(int? id)
        {
            var planoConta = _obterPlanoContaPorIdUseCase.GetPlanoConta(id);
            return View(planoConta);
        }

        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(PlanoContaModel input)
        {
            _cadastrarPlanoContaUseCase.CadastrarPlanoConta(input);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _removePlanoConta.Excluir(id);
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