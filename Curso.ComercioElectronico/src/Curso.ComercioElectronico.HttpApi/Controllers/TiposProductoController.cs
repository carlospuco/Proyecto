

using Curso.ComercioElectronico.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.HttpApi.Controllers;


[ApiController]
[Route("[controller]")]
[Authorize]
public class TiposProductoController
{

    private readonly ITipoProductoAppService tipoProductoAppService;

    public TiposProductoController(ITipoProductoAppService tipoProductoAppService)
    {
        this.tipoProductoAppService = tipoProductoAppService;
    }

    [HttpGet]
    public ICollection<TipoProductoDto> GetAll()
    {

        return tipoProductoAppService.GetAll();
    }

    [HttpPost]
    public async Task<TipoProductoDto> CreateAsync(TipoProductoCreateUpdateDto producto)
    {

        return await tipoProductoAppService.CreateAsync(producto);

    }

    [HttpPut]
    public async Task UpdateAsync(int id, TipoProductoCreateUpdateDto producto)
    {

        await tipoProductoAppService.UpdateAsync(id, producto);

    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(int tipoProductoId)
    {

        return await tipoProductoAppService.DeleteAsync(tipoProductoId);

    }

}
