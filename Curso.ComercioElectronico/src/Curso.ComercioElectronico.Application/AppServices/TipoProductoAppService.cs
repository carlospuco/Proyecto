using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application;

public class TipoProductoAppService:ITipoProductoAppService
{
    private readonly ITipoProductoRepository repository;
    //private readonly IUnitOfWork unitOfWork;

    public TipoProductoAppService(ITipoProductoRepository repository)
    {
        this.repository = repository;
        //this.unitOfWork = unitOfWork;
    }

    public async Task<TipoProductoDto> CreateAsync(TipoProductoCreateUpdateDto tipoProductoDto)
    {
        
        var tipoProducto = new TipoProducto();
        tipoProducto.Descripcion = tipoProductoDto.Descripcion;
        tipoProducto.Nombre = tipoProductoDto.Nombre;

        tipoProducto = await repository.AddAsync(tipoProducto);

        var tipoProductoCreado = new TipoProductoDto();
        tipoProductoCreado.Descripcion = tipoProducto.Descripcion;
        tipoProductoCreado.Nombre = tipoProducto.Nombre;
        tipoProductoCreado.Id = tipoProducto.Id;

        return tipoProductoCreado;
    }

    public async Task UpdateAsync(int id, TipoProductoCreateUpdateDto tipoProductoDto)
    {
        var tipoProducto = await repository.GetByIdAsync(id);
        if (tipoProducto == null){
            throw new ArgumentException($"Tipo Producto con el id: {id}, no existe");
        }
        

        //Mapeo Dto => Entidad
        tipoProducto.Descripcion = tipoProductoDto.Descripcion;
        tipoProducto.Nombre = tipoProductoDto.Nombre;


        //Persistencia objeto
        await repository.UpdateAsync(tipoProducto);
        //await unitOfWork.SaveChangesAsync();

        return;
    }

    public async Task<bool> DeleteAsync(int tipoProductoId)
    {
        //Reglas Validaciones... 
        var tipoProducto = await repository.GetByIdAsync(tipoProductoId);
        if (tipoProducto == null){
            throw new ArgumentException($"Tipo Producto con el id: {tipoProductoId}, no existe");
        }

        repository.Delete(tipoProducto);
        //await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<TipoProductoDto> GetAll()
    {
        var tipoProductoList = repository.GetAll();

        var tipoProductoListDto =  from t in tipoProductoList
                            select new TipoProductoDto(){
                                Id = t.Id,
                                Descripcion = t.Descripcion,
                                Nombre = t.Nombre
                            };

        return tipoProductoListDto.ToList();
    }
}
