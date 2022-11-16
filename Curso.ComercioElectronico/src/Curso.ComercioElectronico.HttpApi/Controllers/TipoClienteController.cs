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
    public class TipoClienteController : ControllerBase
    {
        private readonly ITipoClienteAppService clienteTipoAppService;

        public TipoClienteController(ITipoClienteAppService clienteTipoAppService)
        {
            this.clienteTipoAppService = clienteTipoAppService;
        }

       
        [HttpGet]
        public ListaPaginada<TipoClienteDto> GetAll(int limit = 10, int offset = 0)
        {

            return clienteTipoAppService.GetAll(limit, offset);

        }


        [HttpPost]
        public async Task<TipoClienteDto> CreateAsync(TipoClienteCrearActualizarDto cliente)
        {

            return await clienteTipoAppService.CreateAsync(cliente);

        }

        [HttpPut]
        public async Task UpdateAsync(Guid id, TipoClienteCrearActualizarDto cliente)
        {

            await clienteTipoAppService.UpdateAsync(id, cliente);

        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(Guid clienteId)
        {

            return await clienteTipoAppService.DeleteAsync(clienteId);

        }
    }
}