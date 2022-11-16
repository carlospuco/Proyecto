using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Domain.Entidades;

namespace Curso.ComercioElectronico.Domain.Repositorio
{
    public interface ICarroItemRepository : IRepository<CarroItem, Guid>
    {
        Task<bool> ExisteId( Guid idExcluir);

        IQueryable<CarroItem> GetByText(int limit = 10, int offset = 0,string campo="",string parametro="");
    }
}