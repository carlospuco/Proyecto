namespace Curso.ComercioElectronico.Application;

using System.Reflection;
using Curso.ComercioElectronico.Application.AppServices;
using Curso.ComercioElectronico.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddAplication(this IServiceCollection services, IConfiguration configuration){

        services.AddTransient<IMarcaAppService, MarcaAppService>();
        services.AddTransient<ITipoProductoAppService, TipoProductoAppService>();
        services.AddTransient<IProductoAppService, ProductoAppService>();
        services.AddTransient<IClienteAppService, ClienteAppService>();
        services.AddTransient<IOrdenAppservice, OrdenAppService>();
        services.AddTransient<IOrdenItemAppService, OrdenItemAppService>();
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;

    }

}
