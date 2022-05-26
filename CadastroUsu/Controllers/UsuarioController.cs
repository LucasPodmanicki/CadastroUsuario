using CadastroUsu.Models;
using CadastroUsu.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroUsu.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            var usuarios = _usuarioRepositorio.BuscarTodos();

            return View(usuarios);

        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario Criado Com Sucesso!";
                    return RedirectToAction("index"); // retorna a pag principal

                }
                return View(usuario);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Houve um erro ao cadastrar o usuario!," +
                    $"detalhe do erro: {erro.Message}";
                return RedirectToAction("index"); // retorna a pag principal

            }
        }

        public IActionResult ApagarConfirmacao(int i)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorID(i); // Confirmação se quer apagar um usuario
            return View(usuario);
        }


        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado) TempData["MensagemSucesso"] = "Usuario apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos cadastrar seu usuario, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu usuario, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorID(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {

            try
            {
                
                UsuarioModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Name = usuarioSemSenhaModel.Name,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil
                    };
                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario Atualizado Com Sucesso!";
                    return RedirectToAction("index"); // retorna a pag principal

                }
                return View(usuario);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Houve um erro ao atualizar o usuario!," +
                    $"detalhe do erro: {erro.Message}";
                return RedirectToAction("index"); // retorna a pag principal
            }
        }



    }
    }

