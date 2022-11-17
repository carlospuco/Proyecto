using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio.Entitity;

namespace Ejercicio.Aplicacion
{
    public class RickAppService : IRickAppService
    {
           public ListaPaginada<RickAndMorty> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "")
        {

             var client = new RestClient("https://rickandmortyapi.com/api/character");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            
        }
    }
}