using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Application.Dtos;
using Curso.ComercioElectronico.Application;


namespace Curso.ComercioElectronico.Application.Interfaces
{
    public interface IOrdenItemAppService
    {
        ListaPaginada<OrdenItemDto> GetAll(int limit = 10, int offset = 0);
        ListaPaginada<OrdenItemDto> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "");

        Task<OrdenItemDto> CreateAsync(OrdenItemCrearActualizarDto ordenItem);

        Task UpdateAsync(Guid id, OrdenItemCrearActualizarDto ordenItem);

        Task<bool> DeleteAsync(Guid ordenitemId);
    }
}