using CadastroUsu.Models;
using CadastroUsu.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroUsu.Controllers
{
    public class ContatoController : Controller
    {

        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            var contatos = _contatoRepositorio.BuscarTodos();

            return View(contatos);

        }
        public IActionResult Criar()
        {
            return View();
        }


        [Route("Editar/{i}")]
        public IActionResult Editar(int i) // Passando o ID especifico para a edição
        {
            ContatoModel contato = _contatoRepositorio.ListarPodId(i);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int i)
        {
            ContatoModel contato = _contatoRepositorio.ListarPodId(i); // Confirmação se quer apagar um usuario
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado) TempData["MensagemSucesso"] = "Contato apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos cadastrar seu contato, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Criado Com Sucesso!";
                    return RedirectToAction("index"); // retorna a pag principal

                }
                return View(contato);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Houve um erro ao cadastrar o usuario!," +
                    $"detalhe do erro: {erro.Message}";
                return RedirectToAction("index"); // retorna a pag principal

            }
        }





        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato Atualizado Com Sucesso!";
                    return RedirectToAction("index"); // retorna a pag principal

                }
                return View(contato);
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
