using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Domain.Entidades;
using Curso.ComercioElectronico.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Infraestructure.RepositorioInfrestructura
{
    public class OrdenItemRepository : EfRepository<OrdenItem, Guid>, IOrdenItemRepository
    {
        public OrdenItemRepository(ComercioElectronicoDbContext context) : base(context)
        {
        }

        public async  Task<bool> ExisteNombre(string nombre)
        {
                var resultado = await this._context.Set<OrdenItem>()
                    .AnyAsync(x => x.Nombre.ToUpper() == nombre.ToUpper());

                return resultado;
        }

        public async Task<bool> ExisteNombre(string nombre, Guid idExcluir)
        {
            var query =  this._context.Set<OrdenItem>()
                        .Where(x => x.Id != idExcluir)
                        .Where(x => x.Nombre.ToUpper() == nombre.ToUpper())
                        ;

            var resultado = await query.AnyAsync();

            return resultado;
        }

        public IQueryable<OrdenItem> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "")
        {
            IQueryable<OrdenItem> listaQuery;
            switch(campo)
            {
                case "nombre":
                listaQuery=_context.Set<OrdenItem>().Where(x=>x.Nombre.ToUpper().Contains(parametro.ToUpper())).Select(x=>x).Take(limit).Skip(offset);
                break;
                default:
                listaQuery=_context.Set<OrdenItem>().Where(x=>x.Nombre.ToUpper().Contains(parametro.ToUpper())).Select(x=>x).Take(limit).Skip(offset);
                break;
            }  
            return listaQuery; 
        }

      
    }
}