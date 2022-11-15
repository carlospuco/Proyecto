using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Domain
{
    public interface IClienteRepository :  IRepository<Cliente, Guid>
    {
        Task<bool> ExisteNombre(string nombre);
        Task<bool> ExisteNombre(string nombre, Guid idExcluir);

    }
}