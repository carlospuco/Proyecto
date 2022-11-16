using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Application.Dtos;

namespace Curso.ComercioElectronico.Application.Interfaces
{
    public interface ICarroItemAppService
    {
        ListaPaginada<CarroItemDto> GetAll(int limit = 10, int offset = 0);
        ListaPaginada<CarroItemDto> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "");

        Task<CarroItemDto> CreateAsync(CarroItemCrearActualizarDto carro);

        Task UpdateAsync(Guid id, CarroItemCrearActualizarDto carro);

        Task<bool> DeleteAsync(Guid carroId);
    }
}