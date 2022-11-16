using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Domain;
using Curso.ComercioElectronico.Domain.Entidades;

namespace Curso.ComercioElectronico.Application.Dtos
{
    public class CarroItemDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]

        public Guid CarroId {get;set;}
        public Carro Carro {set;get;}

        public Guid ProductoId {get;set;}
        public Producto Producto {set;get;}
    }
}