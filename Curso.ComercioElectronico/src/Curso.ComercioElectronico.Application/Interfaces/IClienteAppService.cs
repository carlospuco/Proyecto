using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Application
{
    public interface IClienteAppService
    {
    ListaPaginada<ClienteDto> GetAll(int limit=10,int offset=0);
    ListaPaginada<ClienteDto> GetByText(int limit=10,int offset=0,string campo="",string parametro="");

    Task<ClienteDto> CreateAsync(ClienteCrearActualizarDto cliente);

    Task UpdateAsync ( Guid id, ClienteCrearActualizarDto cliente);

    Task<bool> DeleteAsync(Guid clienteId);
    }
}


        