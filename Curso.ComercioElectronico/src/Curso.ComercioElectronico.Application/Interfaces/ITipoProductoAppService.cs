namespace Curso.ComercioElectronico.Application;

public interface ITipoProductoAppService
{
    ICollection<TipoProductoDto> GetAll();

    Task<TipoProductoDto> CreateAsync(TipoProductoCreateUpdateDto tipoProducto);

    Task UpdateAsync (int id, TipoProductoCreateUpdateDto tipoProducto);

    Task<bool> DeleteAsync(int tipoProductoId);
}
