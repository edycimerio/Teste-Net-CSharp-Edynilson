using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Blog.Domain.Entities;

namespace Teste.Blog.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioByUserName(string username);
        Task<Usuario> GetUsuarioById(int id);
        Task InsertUsuario(Usuario usuario);
    }
}
