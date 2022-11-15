using System.Text.Json;
using AutoMapper;
using Curso.ComercioElectronico.Domain;


namespace Curso.ComercioElectronico.Application;

public class ProductoAppService : IProductoAppService
{
    private readonly IProductoRepository repository;
    private readonly IMapper map;
    private readonly IMarcaRepository marcaRepository;
    private readonly ITipoProductoRepository tipoProductoRepository;

    //private readonly IUnitOfWork unitOfWork;

    public ProductoAppService(IProductoRepository repository, IMapper map, IMarcaRepository marcaRepository,
            ITipoProductoRepository tipoProductoRepository)
    {
        this.repository = repository;
        this.map = map;
        this.marcaRepository = marcaRepository;
        this.tipoProductoRepository = tipoProductoRepository;
        //this.unitOfWork = unitOfWork;
    }

    public async Task<ProductoDto> CreateAsync(ProductoCrearActualizarDto productoDto)
    {
            // var producto = new Producto();
            // producto.Nombre=productoDto.Nombre;
            // producto.Precio=productoDto.Precio;
            // producto.Observaciones=productoDto.Observaciones;
            // producto.Caducidad=productoDto.Caducidad;
            // // producto.ProductoId=productoDto.ProductoId;
            // producto.Codigo=productoDto.Codigo;
            // producto.TipoProductoId=productoDto.TipoProductoId;
            // producto.MarcaId=productoDto.MarcaId;

            // //Persistencia objeto
            // producto = await repository.AddAsync(producto);
            // //await unitOfWork.SaveChangesAsync();
             //await repository..SaveChangesAsync();
            // return await GetByIdAsync(producto.Id);

            // //Mapeo Entidad => Dto
            // var productoCreado = new ProductoDto();
            // productoCreado.Id=producto.Id;
            // productoCreado.Nombre=producto.Nombre;
            // productoCreado.Precio=producto.Precio;
            // productoCreado.Observaciones=producto.Observaciones;
            // productoCreado.Caducidad=producto.Caducidad;
            // productoCreado.Codigo=producto.Codigo;
            // // productoCreado.ProductoId=producto.ProductoId;
            // productoCreado.TipoProductoId=producto.TipoProductoId;
            // productoCreado.MarcaId=producto.MarcaId;
            //return productoCreado; 
            //mapeo de DTo a la entidad 
             //Mapeo Dto => Entidad
        
            var productoMapeo = map.Map<Producto>(productoDto);
            productoMapeo = await repository.AddAsync(productoMapeo);
            var productoMapeoDto = map.Map<ProductoDto>(productoMapeo);
            return productoMapeoDto;

    }

    public async Task<bool> DeleteAsync(Guid productoId)
    {
        //Reglas Validaciones... 
        var producto = await repository.GetByIdAsync(productoId);
        if (producto == null){
            throw new ArgumentException($"La producto con el id: {productoId}, no existe");
        }

        repository.Delete(producto);
        //await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ListaPaginada<ProductoDto> GetAll(int limit = 10, int offset = 0)
    {
        var productoList = repository.GetAll();

        var productoListDto =  from m in productoList
                            select new ProductoDto(){
                                Id = m.Id,
                                Nombre = m.Nombre
                            };
        var listaPag = new ListaPaginada<ProductoDto>();
        listaPag.Lista=productoListDto.ToList();
        listaPag.Total=productoListDto.ToList().Count();
        return listaPag;
    }

    public ListaPaginada<ProductoDto> GetByText(int limit = 10, int offset = 0,string campo="",string parametro="")
    {
        var productoList = repository.GetAllIncluding(x=>x.TipoProducto, x=>x.Marca);


        foreach(var iterP in productoList)
        {
            System.Console.WriteLine(JsonSerializer.Serialize(iterP));
        }

        // var productoListDto =  from p in productoList
        //                     select new ProductoDto(){
        //                         Id = p.Id,
        //                         Nombre = p.Nombre,
        //                         Codigo = p.Codigo,
        //                         MarcaId = p.MarcaId,
        //                         Precio = p.Precio,
        //                         Observaciones=p.Observaciones,
        //                         Caducidad=p.Caducidad,
        //                         TipoProductoId=p.TipoProductoId,
        //                         Marca=p.Marca,
        //                         TipoProducto=p.TipoProducto
        //                     };

        var productoListDto = productoList.Skip(offset)
                                .Take(limit)
                                .Select(
                                    p => new ProductoDto()
                                    {
                                        Id = p.Id,
                                        Nombre = p.Nombre,
                                        Codigo = p.Codigo,
                                        MarcaId = p.MarcaId,
                                        Precio = p.Precio,
                                        Observaciones=p.Observaciones,
                                        Caducidad=p.Caducidad,
                                        TipoProductoId=p.TipoProductoId,
                                        Marca=p.Marca,
                                        TipoProducto=p.TipoProducto
                                    }
                                );
                        
        var listaPag = new ListaPaginada<ProductoDto>();
        listaPag.Lista=productoListDto.ToList();
        listaPag.Total=productoListDto.ToList().Count();
        return listaPag;
    }

    public async Task UpdateAsync(Guid id, ProductoCrearActualizarDto productoDto)
    {
        var producto = await repository.GetByIdAsync(id);
        if (producto == null){
            throw new ArgumentException($"La producto con el id: {id}, no existe");
        }
        
        //Mapeo Dto => Entidad
        producto.Nombre = productoDto.Nombre;

        //Persistencia objeto
        await repository.UpdateAsync(producto);
        //await unitOfWork.SaveChangesAsync();

        return;
    }
}
