using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Blog.Domain.Entities;
using Teste.Blog.Domain.Request;
using Teste.Blog.Domain.Response;

namespace Teste.Blog.Domain.Interfaces.Services
{
    public interface IPostagemService
    {
        Task<PostagemResponse> GetPostagemtById(int id);        
        Task InsertPostagem(PostagemRequest request);
        Task UpdatePostagem(PostagemRequest request);
        Task DeletePostagem(int id);
        Task<IEnumerable<PostagemResponse>> GetAllPostagemt();
    }
}
