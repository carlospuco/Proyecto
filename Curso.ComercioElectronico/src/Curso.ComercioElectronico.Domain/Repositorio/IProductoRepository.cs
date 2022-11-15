namespace Curso.ComercioElectronico.Domain;

public interface IProductoRepository :  IRepository<Producto, Guid> {


  IQueryable<Producto> GetByText(int limit = 10, int offset = 0,string campo="",string parametro="");
  

}
