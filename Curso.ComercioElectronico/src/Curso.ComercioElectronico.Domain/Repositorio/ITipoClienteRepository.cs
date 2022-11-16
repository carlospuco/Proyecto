using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Domain.Entidades;

namespace Curso.ComercioElectronico.Domain.Repositorio
{
    public interface ITipoClienteRepository : IRepository<TipoCliente, Guid>
    {
        Task<bool> ExisteNombre(string nombre);
        Task<bool> ExisteNombre(string nombre, Guid idExcluir);
        
    }
}