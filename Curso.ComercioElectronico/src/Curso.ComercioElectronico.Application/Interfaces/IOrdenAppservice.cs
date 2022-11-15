using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Application.Dtos;
using Curso.ComercioElectronico.Application;

namespace Curso.ComercioElectronico.Application.Interfaces
{
    public interface IOrdenAppservice
    {
        ListaPaginada<OrdenDto> GetAll(int limit = 10, int offset = 0);
        ListaPaginada<OrdenDto> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "");

        Task<OrdenDto> CreateAsync(OrdenCrearActualizarDto orden);

        Task UpdateAsync(Guid id, OrdenCrearActualizarDto orden);

        Task<bool> DeleteAsync(Guid ordenId);
    }
}