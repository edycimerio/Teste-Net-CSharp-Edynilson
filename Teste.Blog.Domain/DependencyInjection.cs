using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Teste.Blog.Domain.Interfaces.Services;
using Teste.Blog.Domain.Services;

namespace Teste.Blog.Domain
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IPostagemService, PostagemService>();
            

            return services;
        }
    }
}
