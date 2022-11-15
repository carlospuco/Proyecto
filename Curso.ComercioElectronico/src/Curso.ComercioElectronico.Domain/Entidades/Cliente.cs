using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Domain
{
    public class Cliente
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