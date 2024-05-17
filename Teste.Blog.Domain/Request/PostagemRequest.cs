using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Blog.Domain.Request
{
    public class PostagemRequest
    {
        public int IdPostagem { get; set; }
        public string TituloPostagem { get; set; }
        public string ConteudoPostagem { get; set; }
        public int UsuarioIdPostagem { get; set; }
        public DateTime DataCriacaoPostagem { get; set; }
    }
}
