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
        public class OrdenItemController : ControllerBase
        {
            private readonly IOrdenItemAppService ordenItemAppService;

            public OrdenItemController(IOrdenItemAppService ordenItemAppService)
            {
                this.ordenItemAppService = ordenItemAppService;
            }

            [HttpGet]
            public ListaPaginada<OrdenItemDto> GetAll(int limit = 10, int offset = 0)
            {

                return ordenItemAppService.GetAll(limit, offset);

            }

            [HttpGet("{campo}/{parametro}")]
            public ListaPaginada<OrdenItemDto> GetAll([FromQuery] int limit = 10, [FromQuery] int offset = 0, [FromRoute] string campo = "", [FromRoute] string parametro = "")
            {

                return ordenItemAppService.GetByText(limit, offset, campo, parametro);

            }

            [HttpPost]
            public async Task<OrdenItemDto> CreateAsync(OrdenItemCrearActualizarDto ordenItem)
            {

                return await ordenItemAppService.CreateAsync(ordenItem);

            }

            [HttpPut]
            public async Task UpdateAsync(Guid id, OrdenItemCrearActualizarDto ordenItem)
            {

                await ordenItemAppService.UpdateAsync(id, ordenItem);

            }

            [HttpDelete]
            public async Task<bool> DeleteAsync(Guid ordenItemId)
            {

                return await ordenItemAppService.DeleteAsync(ordenItemId);

            }
        }
    }