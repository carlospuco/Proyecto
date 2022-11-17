using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio.Aplicacion;
using Ejercicio.Entitity;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RickController : ControllerBase
    {

        private readonly ILogger<RickController> _logger;
        private readonly IRickAppService rick;

        public RickController(ILogger<RickController> logger, IRickAppService rick)
        {
            _logger = logger;
            this.rick = rick;
        }

        [HttpGet(Name = "Get")]
      
        public Task<RickAndMorty> GetAll([FromQuery] int limit = 10, [FromQuery] int offset = 0, [FromRoute] string campo = "", [FromRoute] string parametro = "")
        {

            return rick.GetByText(limit, offset, campo, parametro);

        }
    }
}