using App.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Site.ViewModels;
using System.Diagnostics;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepositoy _fornecedorRepositoy;

        public HomeController(ILogger<HomeController> logger
            , IProdutoRepository produtoRepository, IFornecedorRepositoy fornecedorRepositoy)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
            _fornecedorRepositoy = fornecedorRepositoy;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}