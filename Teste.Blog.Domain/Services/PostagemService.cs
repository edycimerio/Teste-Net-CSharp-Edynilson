using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Blog.Domain.Entities;
using Teste.Blog.Domain.Interfaces.Repository;
using Teste.Blog.Domain.Interfaces.Services;
using Teste.Blog.Domain.Request;
using Teste.Blog.Domain.Response;

namespace Teste.Blog.Domain.Services
{
    public class PostagemService: IPostagemService
    {
        private readonly IPostagemRepository _postagemRepository;

        

        public PostagemService(IPostagemRepository postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }

        public async Task<PostagemResponse> GetPostagemtById(int id)
        {
            var postagem =  await _postagemRepository.GetPostagemtById(id);

            PostagemResponse request = new PostagemResponse();
            if (postagem != null)
            {
                request.IdPostagem = postagem.Id;
                request.TituloPostagem = postagem.Titulo;
                request.ConteudoPostagem = postagem.Conteudo;
                request.UsuarioIdPostagem = postagem.UsuarioId;
            }

            return request;
        }
               
        public async Task InsertPostagem(PostagemRequest request)
        {
            Postagem post = new Postagem();
            post.Titulo = request.TituloPostagem;
            post.Conteudo = request.ConteudoPostagem;
            post.UsuarioId = request.UsuarioIdPostagem;
            post.DataCriacao = DateTime.Now;

            await _postagemRepository.InsertPostagem(post);
        }

        public async Task UpdatePostagem(PostagemRequest request)
        {
            Postagem post = new Postagem();
            post.Id = request.IdPostagem;
            post.Titulo = request.TituloPostagem;
            post.Conteudo = request.ConteudoPostagem;
            post.UsuarioId = request.UsuarioIdPostagem;
            

            await _postagemRepository.UpdatePostagem(post);
        }

        public async Task DeletePostagem(int id)
        {
            await _postagemRepository.DeletePostagem(id);
        }

        public async Task<IEnumerable<PostagemResponse>> GetAllPostagemt()
        {
            var postagem = await _postagemRepository.GetAllPostagemt();

            IList<PostagemResponse> lista = new List<PostagemResponse>();
            IEnumerable<PostagemResponse> retorno = null;

            foreach (var item in postagem)
            {
                PostagemResponse response = new PostagemResponse();
                response.IdPostagem = item.Id;
                response.TituloPostagem = item.Titulo;
                response.ConteudoPostagem = item.Conteudo;
                response.UsuarioIdPostagem = item.UsuarioId;

                lista.Add(response);    
            }

            retorno = lista;

            return retorno;
        }
    }
}
