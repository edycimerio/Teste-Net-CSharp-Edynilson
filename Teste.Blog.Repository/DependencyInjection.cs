using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Blog.Domain.Interfaces.Repository;

namespace Teste.Blog.Repository
{   

    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPostagemRepository, PostagemRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();            

            return services;
        }
    }
}
