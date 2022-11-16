using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application.Dtos
{
    public class CarroDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int CantidadProductos {get;set;}
        public Guid ClienteId {get;set;}
        public Cliente Cliente {set;get;}
    }
}