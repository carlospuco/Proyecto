using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio.Entitity;

namespace Ejercicio.Aplicacion
{
    public class RickAppService : IRickAppService
    {
        public Task<RickAndMorty> CreateAsync(RickAndMorty rick)
        {
            throw new NotImplementedException();
        }

        public Task<RickAndMorty> GetAll(int limit = 10, int offset = 0)
        {
            var client = new RestClient("https://rickandmortyapi.com/api/character");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}