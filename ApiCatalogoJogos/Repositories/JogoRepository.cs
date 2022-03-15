using ApiCatalogoJogos.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo[id]] = jogo;

            return Task.CompletedTask;

            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);

            return Task.CompletedTask;

            //throw new NotImplementedException();
        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
            //throw new NotImplementedException();
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id)) return null;

            return Task.FromResult(jogos[id]);

            //throw new NotImplementedException();
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());

            //throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);

            return Task.CompletedTask;

            //throw new NotImplementedException();
        }
    }
}
