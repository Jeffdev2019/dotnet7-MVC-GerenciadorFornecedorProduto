using Dev.IO.App.Extensions;
using Dev.IO.Business.Interfaces.Repository;
using Dev.IO.Business.Interfaces.Service;
using Dev.IO.Business.Services;
using Dev.IO.Data.Context;
using Dev.IO.Data.Repository;
using DevIO.Business.Intefaces;
using DevIO.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace Dev.IO.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IFornecedorService, FornecedorService>();

            services.AddScoped<INotificador, Notificador>();


            return services;
        }
    }

    
}
