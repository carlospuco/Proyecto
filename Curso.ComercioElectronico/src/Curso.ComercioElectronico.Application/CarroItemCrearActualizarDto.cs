using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Application
{
    public class CarroItemCrearActualizarDto
    {
        [Required]
        public Guid CarroId {get;set;}
        

        public Guid ProductoId {get;set;}
    
    }
}