using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Blog.Domain.Request
{
    public class UsuarioRequest
    {
        public int IdUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string SobreNomeUsuario { get; set; }
    }
}
