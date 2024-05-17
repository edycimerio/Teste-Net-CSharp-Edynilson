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
    public class PostagemRepository : IPostagemRepository
    {
        private readonly BlogContext _context;

        public PostagemRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task<Postagem> GetPostagemtById(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<IEnumerable<Postagem>> GetAllPostagemt()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task InsertPostagem(Postagem post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostagem(Postagem post)
        {
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostagem(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }
    }
}
