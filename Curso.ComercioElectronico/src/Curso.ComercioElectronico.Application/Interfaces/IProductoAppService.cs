using System.ComponentModel.DataAnnotations;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application;



public interface IProductoAppService
{

    ListaPaginada<ProductoDto> GetAll(int limit=10,int offset=0);
    ListaPaginada<ProductoDto> GetByText(int limit=10,int offset=0,string campo="",string parametro="");

    Task<ProductoDto> CreateAsync(ProductoCrearActualizarDto producto);

    Task UpdateAsync (Guid id, ProductoCrearActualizarDto producto);

    Task<bool> DeleteAsync(Guid marcaId);
}


