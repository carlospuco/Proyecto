using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Domain;
using Curso.ComercioElectronico.Domain.Entidades;
using Curso.ComercioElectronico.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;


namespace Curso.ComercioElectronico.Infraestructure.RepositorioInfrestructura
{
    public class OrdenRepository : EfRepository<Orden, Guid>, IOrdenRepository
    {
        public OrdenRepository(ComercioElectronicoDbContext context) : base(context)
        {
        }

        public async Task<bool> ExisteNombre(string nombre) {

        var resultado = await this._context.Set<Orden>()
                    .AnyAsync(x => x.Nombre.ToUpper() == nombre.ToUpper());

        return resultado;
        }


        public async Task<bool> ExisteNombre(string nombre, Guid idExcluir)  {

            var query =  this._context.Set<Orden>()
                        .Where(x => x.Id != idExcluir)
                        .Where(x => x.Nombre.ToUpper() == nombre.ToUpper())
                        ;

            var resultado = await query.AnyAsync();

            return resultado;
        }

        public virtual IQueryable<Orden> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "")
        {
            IQueryable<Orden> listaQuery;
            switch(campo)
            {
                case "nombre":
                listaQuery=_context.Set<Orden>().Where(x=>x.Nombre.ToUpper().Contains(parametro.ToUpper())).Select(x=>x).Take(limit).Skip(offset);
                break;
                default:
                listaQuery=_context.Set<Orden>().Where(x=>x.Nombre.ToUpper().Contains(parametro.ToUpper())).Select(x=>x).Take(limit).Skip(offset);
                break;
            }  
            return listaQuery;      
        }
    }
    
}