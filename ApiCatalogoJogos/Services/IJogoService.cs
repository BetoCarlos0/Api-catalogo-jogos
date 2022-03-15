using ApiCatalogoJogos.ImputModel;
using ApiCatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Services
{
    public interface IJogoService : IDisposable
    {
        Task<List<JogoViewModel>> Obter(int pagina, int quantidade);
        Task<JogoViewModel> Obter(Guid id);
        Task<JogoViewModel> Inserir(JogoInputModel jogoInputModel);
        Task Atualizar(Guid id, JogoInputModel jogoInputModel);
        Task Atualizar(Guid id, double Preco);
        Task Remover(Guid id);
    }
}
