using CadastroUsu.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsu.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
