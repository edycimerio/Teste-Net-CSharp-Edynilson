using BlogApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Blog.Domain.Entities;
using Teste.Blog.Domain.Interfaces.Repository;

namespace Teste.Blog.Repository
{

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BlogContext _context;

        public UsuarioRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuarioByUserName(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Login == username);
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task InsertUsuario(Usuario user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }

}
