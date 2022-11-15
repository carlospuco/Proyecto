using System.ComponentModel.DataAnnotations;

namespace Curso.ComercioElectronico.Application;

public class TipoProductoDto
{   
    private int _id;
 
    private string _descripcion;
    private string _nombre;

    public TipoProductoDto()
    {
    }

    public TipoProductoDto(int id, string nombre, string descripcion)
    {
        _id = id;
        _nombre = nombre;
        _descripcion = descripcion;
    }

    public int Id { get => _id; set => _id = value; }
    public string Nombre { get => _nombre; set => _nombre = value; }
    public string Descripcion { get => _descripcion; set => _descripcion = value; }
}
