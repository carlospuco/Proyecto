using Curso.ComercioElectronico.Domain;
using Microsoft.EntityFrameworkCore;
using Curso.ComercioElectronico.Domain.Entidades;

namespace Curso.ComercioElectronico.Infraestructure;

public class ComercioElectronicoDbContext:DbContext, IUnitOfWork
{

    //Agregar sus entidades
    public DbSet<Marca> Marcas {get;set;}

    public DbSet<TipoProducto> TiposProducto{get;set;}
    public DbSet<Producto> Productos{get;set;}

    public DbSet<Cliente> Clientes{get;set;}
    public DbSet<Orden> Ordenes{get;set;}

    public DbSet<OrdenItem> OrdenesItems{get;set;}

    public DbSet<TipoCliente> TiposClientes{get;set;}

    public DbSet<Carro> Carros{get;set;}

    public DbSet<CarroItem> CarrosItems{get;set;}


    public string DbPath { get; set; }

    public ComercioElectronicoDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join("C:/Users/carlo/Documents/NET/Curso.ComercioElectronico/src/Curso.ComercioElectronico.Infraestructure/db", "curso.comercio-electronicov2.db");

    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

} 



