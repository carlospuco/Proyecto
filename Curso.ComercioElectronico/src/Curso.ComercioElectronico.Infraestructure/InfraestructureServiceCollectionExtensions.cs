namespace Curso.ComercioElectronico.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using  Curso.ComercioElectronico.Domain;
using Curso.ComercioElectronico.Domain.Repositorio;
using Curso.ComercioElectronico.Infraestructure.RepositorioInfrestructura;

public static class InfraestructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration){

        //Configuraciones de Dependencias
        services.AddScoped<ComercioElectronicoDbContext>();
        //builder.Services.AddScoped<IUnitOfWork, ComercioElectronicoDbContext>();
        services.AddTransient<IMarcaRepository, MarcaRepository>();      
        services.AddTransient<ITipoProductoRepository, TipoProductoRepository>();
        services.AddTransient<IProductoRepository, ProductoRepository>();
        services.AddTransient<IClienteRepository, ClienteRepository>();
        services.AddTransient<IOrdenRepository, OrdenRepository>();
        services.AddTransient<IOrdenItemRepository, OrdenItemRepository>();

        return services;
        

    }

}
