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
    public class CarroItemController : ControllerBase
    {
        private readonly ICarroItemAppService carroItemAppService;

        public CarroItemController(ICarroItemAppService carroItemAppService)
        {
            this.carroItemAppService = carroItemAppService;
        }

        [HttpGet]
        public ListaPaginada<CarroItemDto> GetAll(int limit = 10, int offset = 0)
        {

            return carroItemAppService.GetAll(limit, offset);

        }

        [HttpGet("{campo}/{parametro}")]
        public ListaPaginada<CarroItemDto> GetAll([FromQuery] int limit = 10, [FromQuery] int offset = 0, [FromRoute] string campo = "", [FromRoute] string parametro = "")
        {

            return carroItemAppService.GetByText(limit, offset, campo, parametro);

        }

        [HttpPost]
        public async Task<CarroItemDto> CreateAsync(CarroItemCrearActualizarDto carro)
        {

            return await carroItemAppService.CreateAsync(carro);

        }

        [HttpPut]
        public async Task UpdateAsync(Guid id, CarroItemCrearActualizarDto carro)
        {

            await carroItemAppService.UpdateAsync(id, carro);

        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(Guid carroId)
        {

            return await carroItemAppService.DeleteAsync(carroId);

        }
    }
}