using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Domain.Entidades;

namespace Curso.ComercioElectronico.Domain.Repositorio
{
    public interface ICarroRepository : IRepository<Carro, Guid>
    
    {
        Task<bool> ExisteId( Guid idExcluir);

        IQueryable<Carro> GetByText(int limit = 10, int offset = 0,string campo="",string parametro="");
    }

}