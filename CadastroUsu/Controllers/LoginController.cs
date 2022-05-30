using CadastroUsu.Helper;
using CadastroUsu.Models;
using CadastroUsu.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroUsu.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {

            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            // Se o usuario estiver logado, redirecionar para a Home

            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("index", "Home");
            
            return View();
        }

        IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("index", "login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);



                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha incorreta!";
                    }

                    TempData["MensagemErro"] = $"Usuario ou Senha não estão corretos!   ";

                }
                return View("index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu Login, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
