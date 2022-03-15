﻿using ApiCatalogoJogos.Entities;
using ApiCatalogoJogos.Exceptions;
using ApiCatalogoJogos.ImputModel;
using ApiCatalogoJogos.Repositories;
using ApiCatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task Atualizar(Guid id, JogoInputModel jogoInputModel)
        {
            var entidadeJogo = await _jogoRepository.Obter(id);

            if (entidadeJogo == null) throw new JogoJaCadastradoException();

            entidadeJogo.Nome = jogoInputModel.Nome;
            entidadeJogo.Produtora = jogoInputModel.Produtora;
            entidadeJogo.Preco = jogoInputModel.Preco;

            await _jogoRepository.Atualizar(entidadeJogo);
        }

        public async Task Atualizar(Guid id, double preco)
        {
            var entidadeJogo = await _jogoRepository.Obter(id);

            if (entidadeJogo == null) throw new JogoJaCadastradoException();

            entidadeJogo.Preco = preco;

            await _jogoRepository.Atualizar(entidadeJogo);
        }

        public void Dispose()
        {
            _jogoRepository?.Dispose();
        }

        public async Task<JogoViewModel> Inserir(JogoInputModel jogoInputModel)
        {
            var entidadeJogo = await _jogoRepository.Obter(jogoInputModel.Nome, jogoInputModel.Produtora);

            if (entidadeJogo.Count() > 0) throw new JogoJaCadastradoException();

            var jogoInsert = new Jogo
            {
                Id = Guid.NewGuid(),
                Nome = jogoInputModel.Nome,
                Produtora = jogoInputModel.Produtora,
                Preco = jogoInputModel.Preco
            };

            await _jogoRepository.Inserir(jogoInsert);

            return new JogoViewModel
            {
                Id = jogoInsert.Id,
                Nome = jogoInputModel.Nome,
                Produtora = jogoInputModel.Produtora,
                Preco = jogoInputModel.Preco
            };
        }

        public async Task<List<JogoViewModel>> Obter(int pagina, int quantidade)
        {
            var jogos = await _jogoRepository.Obter(pagina, quantidade);

            return jogos.Select(jogo => new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            }).ToList();
        }

        public async Task<JogoViewModel> Obter(Guid id)
        {
            var jogo = await _jogoRepository.Obter(id);

            if (jogo == null) return null;

            return new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
        }

        public async Task Remover(Guid id)
        {
            var jogo = _jogoRepository.Obter(id);

            if (jogo == null) throw new JogoJaCadastradoException();

            await _jogoRepository.Remover(id);
        }
    }
}