using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application
{
    public class CarroCrearActualizarDto
    {
        [Required]
        public int CantidadProductos {get;set;}
        public Guid ClienteId {get;set;}
    }
    
}