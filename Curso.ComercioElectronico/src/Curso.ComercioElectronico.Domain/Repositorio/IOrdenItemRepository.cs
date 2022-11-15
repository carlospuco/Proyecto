using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Curso.ComercioElectronico.Domain.Entidades;

namespace Curso.ComercioElectronico.Domain.Repositorio
{
    public interface IOrdenItemRepository : IRepository <OrdenItem, Guid>
    {
        
        Task<bool> ExisteNombre(string nombre);

        Task<bool> ExisteNombre(string nombre, Guid idExcluir);

        IQueryable<OrdenItem> GetByText(int limit = 10, int offset = 0,string campo="",string parametro="");
    }
}