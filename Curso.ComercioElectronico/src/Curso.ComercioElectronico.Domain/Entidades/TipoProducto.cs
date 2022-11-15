using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Domain;

public class TipoProducto
{
   
    private int _id;

    private string _descripcion;

    private string _nombre;

    public TipoProducto()
    {
    }

    public TipoProducto(int id, string nombre,string descripcion)
    {
        _id = id;
        _nombre = nombre;
        _descripcion = descripcion;

    }

    public int Id { get => _id; set => _id = value; }
    public string Nombre { get => _nombre; set => _nombre = value; }
    public string Descripcion { get => _descripcion; set => _descripcion = value; }

   
}
