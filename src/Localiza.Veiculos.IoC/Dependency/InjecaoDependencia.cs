using Localiza.Veiculos.Application.Service;
using Localiza.Veiculos.Data.Repository;
using Localiza.Veiculos.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Localiza.Veiculos.IoC.Dependency
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection RegistrarDependencias(this IServiceCollection services)
        {
            services.AddSingleton<Context>();

            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IVeiculoService, VeiculoService>();

            return services;
        }
    }
}
