using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Domain.Entidades;
using Curso.ComercioElectronico.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Infraestructure.RepositorioInfrestructura
{
    public class CarroItemRepository : EfRepository<CarroItem, Guid>, ICarroItemRepository
    {
        public CarroItemRepository(ComercioElectronicoDbContext context) : base(context)
        {
        }

        public async Task<bool> ExisteId(Guid idExcluir)
        {
             var query =  this._context.Set<CarroItem>()
                        .Where(x => x.Id != idExcluir)
                        ;

            var resultado = await query.AnyAsync();

            return resultado;
        }

        public IQueryable<CarroItem> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "")
        {
            throw new NotImplementedException();
        }
    }
}