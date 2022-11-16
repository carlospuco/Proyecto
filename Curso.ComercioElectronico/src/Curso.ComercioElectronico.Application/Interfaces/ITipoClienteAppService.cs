using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Application.Dtos;

namespace Curso.ComercioElectronico.Application.Interfaces
{
    public interface ITipoClienteAppService
    {
        ListaPaginada<TipoClienteDto> GetAll(int limit=10,int offset=0);
        ListaPaginada<TipoClienteDto> GetByText(int limit=10,int offset=0,string campo="",string parametro="");

        Task<TipoClienteDto> CreateAsync(TipoClienteCrearActualizarDto clienteTipo);

        Task UpdateAsync(Guid id, TipoClienteCrearActualizarDto clienteTipo);

        Task<bool> DeleteAsync(Guid clienteTipoId);
    }
}