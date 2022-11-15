using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application
{
    public class ClienteDto
    {
    
        [Required]
        public Guid Id {get;set;}

        [Required]
        [StringLength(DominioConstantes.NOMBRE_MAXIMO)]      
        public string Nombre {get;set;}
        [Required]
        public string Correo {get;set;}
        [Required]
        public string Direccion  {get;set;}
    
    }
}