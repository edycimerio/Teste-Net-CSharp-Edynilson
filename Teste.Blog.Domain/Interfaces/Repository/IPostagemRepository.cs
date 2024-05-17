using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Blog.Domain.Entities;

namespace Teste.Blog.Domain.Interfaces.Repository
{
    public interface IPostagemRepository
    {
        Task<Postagem> GetPostagemtById(int id);       
        Task InsertPostagem(Postagem postagem);
        Task UpdatePostagem(Postagem postagem);
        Task DeletePostagem(int id);
        Task<IEnumerable<Postagem>> GetAllPostagemt();
    }
}
