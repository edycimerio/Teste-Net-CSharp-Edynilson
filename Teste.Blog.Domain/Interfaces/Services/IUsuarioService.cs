using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Blog.Domain.Request;

namespace Teste.Blog.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioRequest> Autenticar(string username, string password);
        Task InsertUsuario(UsuarioRequest user);
    }
}
