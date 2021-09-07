using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new Jogo { Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), Nome = "Genshin Impact", Preco = 10, Produtora = "Mihoyo" }},
            {Guid.Parse("3fa85f64-5717-5562-b3fc-2c963f66afa6"), new Jogo { Id = Guid.Parse("3fa85f64-5717-5562-b3fc-2c963f66afa6"), Nome = "Final Fantasy XV", Preco = 150, Produtora = "Capcom" }}
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;
            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(j => j.Nome.Equals(nome) && j.Produtora.Equals(produtora)).ToList());
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }
                
        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id]= jogo;
            return Task.CompletedTask;
        }
                
        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            // Fechar a conexão com o banco
        }
    }
}
