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
    public class CarroController : ControllerBase
    {
        private readonly ICarroAppService carroAppService;

        public CarroController(ICarroAppService carroAppService)
        {
            this.carroAppService = carroAppService;
        }

        [HttpGet]
        public ListaPaginada<CarroDto> GetAll(int limit = 10, int offset = 0)
        {

            return carroAppService.GetAll(limit, offset);

        }

        [HttpGet("{campo}/{parametro}")]
        public ListaPaginada<CarroDto> GetAll([FromQuery] int limit = 10, [FromQuery] int offset = 0, [FromRoute] string campo = "", [FromRoute] string parametro = "")
        {

            return carroAppService.GetByText(limit, offset, campo, parametro);

        }

        [HttpPost]
        public async Task<CarroDto> CreateAsync(CarroCrearActualizarDto carro)
        {

            return await carroAppService.CreateAsync(carro);

        }

        [HttpPut]
        public async Task UpdateAsync(Guid id, CarroCrearActualizarDto carro)
        {

            await carroAppService.UpdateAsync(id, carro);

        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(Guid carroId)
        {

            return await carroAppService.DeleteAsync(carroId);

        }
    }
}