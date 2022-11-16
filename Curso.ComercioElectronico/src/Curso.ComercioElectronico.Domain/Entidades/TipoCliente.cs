using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Domain.Entidades
{
    public class TipoCliente
    {
        [Required]
        public Guid Id {get;set;}

        [Required]
        [StringLength(DominioConstantes.NOMBRE_MAXIMO)]      
        public string Nombre {get;set;}
        [Required]
        public string TipoEntidadCliente {get;set;}
        [Required]
        public string NumeroCuentaAhorro{get;set;}
        [Required]
        public string NumeroCuentaCorriente{get;set;}
        
    }
}