using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Blog.Domain.Entities;
using Teste.Blog.Domain.Interfaces.Repository;
using Teste.Blog.Domain.Interfaces.Services;
using Teste.Blog.Domain.Request;

namespace Teste.Blog.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioRequest> Autenticar(string username, string password)
        {
            var user = await _usuarioRepository.GetUsuarioByUserName(username);
            if (user == null || user.Password != password)
            {
                return null;
            }
            else
            {
                UsuarioRequest request = new UsuarioRequest();
                request.IdUsuario = user.Id;
                request.LoginUsuario = user.Login;
                request.SenhaUsuario = user.Password;
                request.NomeUsuario = user.Nome;
                request.SobreNomeUsuario = user.SobreNome;

                return request;
            }
           
        }

        public async Task InsertUsuario(UsuarioRequest request)
        {
            Usuario usuario = new Usuario();
            usuario.Login = request.LoginUsuario;
            usuario.Password = request.SenhaUsuario;
            usuario.Nome = request.NomeUsuario;
            usuario.SobreNome = request.SobreNomeUsuario;

            await _usuarioRepository.InsertUsuario(usuario);
        }
    }

}
