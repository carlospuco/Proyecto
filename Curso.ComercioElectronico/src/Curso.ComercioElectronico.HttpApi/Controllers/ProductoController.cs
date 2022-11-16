

using Curso.ComercioElectronico.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.HttpApi.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize]
public class ProductoController : ControllerBase
{

    private readonly IProductoAppService productoAppService;

    public ProductoController(IProductoAppService productoAppService)
    {
        this.productoAppService = productoAppService;
    }

    [HttpGet]
    public ListaPaginada<ProductoDto> GetAll(int limit=10,int offset=0)
    {

        return productoAppService.GetAll(limit,offset);

    }

    [HttpGet("{campo}/{parametro}")]
    public ListaPaginada<ProductoDto> GetAll([FromQuery] int limit=10,[FromQuery] int offset=0,[FromRoute] string campo="",[FromRoute] string parametro="")
    {

        return productoAppService.GetByText(limit,offset,campo,parametro);

    }

    [HttpPost]
    public async Task<ProductoDto> CreateAsync(ProductoCrearActualizarDto producto)
    {

        return await productoAppService.CreateAsync(producto);

    }

    [HttpPut]
    public async Task UpdateAsync(Guid id, ProductoCrearActualizarDto producto)
    {

        await productoAppService.UpdateAsync(id, producto);

    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(Guid productoId)
    {

        return await productoAppService.DeleteAsync(productoId);

    }

}