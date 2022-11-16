using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Domain.Entidades;
using Curso.ComercioElectronico.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Infraestructure.RepositorioInfrestructura
{
    public class TipoClienteRepository : EfRepository<TipoCliente, Guid>, ITipoClienteRepository
    {
        public TipoClienteRepository(ComercioElectronicoDbContext context) : base(context)
        {
            
        }

        public async Task<bool> ExisteNombre(string nombre)
        {
            var resultado = await this._context.Set<TipoCliente>().AnyAsync(x => x.Nombre.ToUpper() == nombre.ToUpper());
            return resultado;
        }

        public async Task<bool> ExisteNombre(string nombre, Guid idExcluir)
        {
            var query = this._context.Set<TipoCliente>()
                    .Where(x => x.Id != idExcluir)
                    .Where(x => x.Nombre.ToUpper() == nombre.ToUpper())
                    ;

            var resultado = await query.AnyAsync();

            return resultado;
        }
    }
}