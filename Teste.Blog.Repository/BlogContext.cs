
using Microsoft.EntityFrameworkCore;
using Teste.Blog.Domain.Entities;


namespace BlogApi.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<Usuario> Users { get; set; }
        public DbSet<Postagem> Posts { get; set; }
    }
}
