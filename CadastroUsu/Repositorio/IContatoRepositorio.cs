using CadastroUsu.Models;
using System.Collections.Generic;

namespace CadastroUsu.Repositorio
{
    public interface IContatoRepositorio
    {
        // Chamar metodos no banco

        ContatoModel ListarPodId(int id);


        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int i);
        
      
        }
    }

