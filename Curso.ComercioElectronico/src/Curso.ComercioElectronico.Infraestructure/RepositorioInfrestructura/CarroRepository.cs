using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Domain.Entidades;
using Curso.ComercioElectronico.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Infraestructure.RepositorioInfrestructura
{
    public class CarroRepository : EfRepository<Carro, Guid>, ICarroRepository
    {
        public CarroRepository(ComercioElectronicoDbContext context) : base(context)
        {
        }

        public async Task<bool> ExisteId(Guid idExcluir)
        {
            var query =  this._context.Set<Carro>()
                        .Where(x => x.Id != idExcluir)
                        ;

            var resultado = await query.AnyAsync();

            return resultado;
        }

        public IQueryable<Carro> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "")
        {
            throw new NotImplementedException();
        }
    }
}