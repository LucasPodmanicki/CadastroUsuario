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


        public IActionResult RedefinirSenha()
        {
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
        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);



                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        _usuarioRepositorio.Atualizar(usuario);



                        TempData["MensagemSucesso"] = $"Enviamos para seu E-Mail cadastrado, uma nova senha!";
                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha!";

                }
                return View("index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos redefinir sua senha, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
