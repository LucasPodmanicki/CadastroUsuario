using CadastroUsu.Data;
using CadastroUsu.Models;
using System.Collections.Generic;
using System.Linq;

namespace CadastroUsu.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {

        private readonly BancoContext _context;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            this._context = bancoContext;
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            // Inserir no banco de dados
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public bool Apagar(int i)
        {
            ContatoModel contatoDB = ListarPodId(i); // Atualizar dados dos usuarios no banco

            if (contatoDB == null) throw new System.Exception("Houve um erro ao deletar seu usuario!");

            _context.Contatos.Remove(contatoDB);
            _context.SaveChanges();

            return true;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPodId(contato.Id); // Atualizar dados dos usuarios no banco

            if(contatoDB == null) throw new System.Exception("Houve um erro ao atualizar o usuario!"); 
            
            contatoDB.Name= contato.Name;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _context.Contatos.Update(contatoDB);
            _context.SaveChanges();

            return contatoDB;
        }


        public List<ContatoModel> BuscarTodos()
        {
            return _context.Contatos.ToList();
        }

        
        public ContatoModel ListarPodId(int id)
        {
            return _context.Contatos.FirstOrDefault(x => x.Id == id);   // Listando o contado pelo ID
        }
    }
    
}
