using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Domain.Entidades
{
    public class Carro
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int CantidadProductos {get;set;}
        public Guid ClienteId {get;set;}
        public Cliente Cliente {set;get;}
    }
}