using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio.Entitity;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RickController : ControllerBase
    {

        private readonly ILogger<RickController> _logger;

        public RickController(ILogger<RickController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Get")]
      
        public ListaPaginada<RickAndMorty> GetAll([FromQuery] int limit = 10, [FromQuery] int offset = 0, [FromRoute] string campo = "", [FromRoute] string parametro = "")
        {

            return _logger.GetByText(limit, offset, campo, parametro);

        }
    }
}