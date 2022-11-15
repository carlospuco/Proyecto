using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Infraestructure;

public class TipoProductoRepository: EfRepository<TipoProducto, int>, ITipoProductoRepository
{
    public TipoProductoRepository(ComercioElectronicoDbContext context) : base(context)
    {
        
    }
}
