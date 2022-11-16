using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Application;
using Curso.ComercioElectronico.Application.Dtos;
using Curso.ComercioElectronico.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.HttpApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OrdenController : ControllerBase
    {
        private readonly IOrdenAppservice ordenAppService;

        public OrdenController(IOrdenAppservice ordenAppService)
        {
            this.ordenAppService = ordenAppService;
        }

        [HttpGet]
        public ListaPaginada<OrdenDto> GetAll(int limit = 10, int offset = 0)
        {

            return ordenAppService.GetAll(limit, offset);

        }

        [HttpGet("{campo}/{parametro}")]
        public ListaPaginada<OrdenDto> GetAll([FromQuery] int limit = 10, [FromQuery] int offset = 0, [FromRoute] string campo = "", [FromRoute] string parametro = "")
        {

            return ordenAppService.GetByText(limit, offset, campo, parametro);

        }

        [HttpPost]
        public async Task<OrdenDto> CreateAsync(OrdenCrearActualizarDto orden)
        {

            return await ordenAppService.CreateAsync(orden);

        }

        [HttpPut]
        public async Task UpdateAsync(Guid id, OrdenCrearActualizarDto orden)
        {

            await ordenAppService.UpdateAsync(id, orden);

        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(Guid ordenId)
        {

            return await ordenAppService.DeleteAsync(ordenId);

        }
    }
}