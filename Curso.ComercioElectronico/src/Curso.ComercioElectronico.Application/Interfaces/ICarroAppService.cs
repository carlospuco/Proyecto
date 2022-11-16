using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Application.Dtos;

namespace Curso.ComercioElectronico.Application.Interfaces
{
    public interface ICarroAppService
    {
        ListaPaginada<CarroDto> GetAll(int limit = 10, int offset = 0);
        ListaPaginada<CarroDto> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "");

        Task<CarroDto> CreateAsync(CarroCrearActualizarDto carro);

        Task UpdateAsync(Guid id, CarroCrearActualizarDto carro);

        Task<bool> DeleteAsync(Guid carroId);
    }
}