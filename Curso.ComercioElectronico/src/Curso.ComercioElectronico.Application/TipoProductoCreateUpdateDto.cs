namespace Curso.ComercioElectronico.Application;

public class TipoProductoCreateUpdateDto
{
    private string _descripcion;

    private string _nombre;

    public TipoProductoCreateUpdateDto()
    {
    }

    public TipoProductoCreateUpdateDto(string nombre,string descripcion)
    {
        _descripcion = descripcion;
        _nombre = nombre;
    }
    public string Nombre { get => _nombre; set => _nombre = value; }
    public string Descripcion { get => _descripcion; set => _descripcion = value; }
}
