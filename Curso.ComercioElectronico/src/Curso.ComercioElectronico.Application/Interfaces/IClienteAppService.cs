using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Application
{
    public interface IClienteAppService
    {
    ICollection<ClienteDto> GetAll();

    Task<ClienteDto> CreateAsync(ClienteCrearActualizarDto cliente);

    Task UpdateAsync ( Guid id, ClienteCrearActualizarDto cliente);

    Task<bool> DeleteAsync(Guid clienteId);
    }
}