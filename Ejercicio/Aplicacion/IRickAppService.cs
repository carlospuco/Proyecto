using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio.Entitity;

namespace Ejercicio.Aplicacion
{
    public interface IRickAppService
    {
      
         Task<RickAndMorty> GetAll(int limit = 10, int offset = 0);
         Task<RickAndMorty> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "");
    }
}