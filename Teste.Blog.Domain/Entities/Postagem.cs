using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Blog.Domain.Entities
{
    public class Postagem
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
