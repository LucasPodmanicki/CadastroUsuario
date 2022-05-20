using Microsoft.AspNetCore.Mvc;

namespace CadastroUsu.Controllers
{
    public class UsuarioControllercs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
