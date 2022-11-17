using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio.Entitity;

namespace Ejercicio.Aplicacion
{
    public interface IRickAppService
    {
      
         ListaPaginada<RickAndMorty> GetAll(int limit = 10, int offset = 0);

    }
}