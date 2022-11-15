using Curso.ComercioElectronico.Domain;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Infraestructure;

public class ProductoRepository: EfRepository<Producto, Guid>, IProductoRepository
{
    public ProductoRepository(ComercioElectronicoDbContext context) : base(context)
    {
        
    }

    public virtual IQueryable<Producto> GetByText(int limit = 10, int offset = 0,string campo="",string parametro="")
    {
        IQueryable<Producto> listaQuery;
        switch(campo)
        {
            case "nombre":
            listaQuery=_context.Set<Producto>().Where(x=>x.Nombre.ToUpper().Contains(parametro.ToUpper())).Select(x=>x).Take(limit).Skip(offset);
            break;
            case "codigo":
            listaQuery=_context.Set<Producto>().Where(x=>x.Codigo.ToUpper().Contains(parametro.ToUpper())).Select(x=>x).Take(limit).Skip(offset);
            break;
            default:
            listaQuery=_context.Set<Producto>().Where(x=>x.Nombre.ToUpper().Contains(parametro.ToUpper())).Select(x=>x).Take(limit).Skip(offset);
            break;
        }
        
        
        return listaQuery;
    }

}
