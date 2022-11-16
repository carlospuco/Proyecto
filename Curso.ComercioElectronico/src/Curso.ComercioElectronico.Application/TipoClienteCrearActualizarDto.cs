using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application
{
    public class TipoClienteCrearActualizarDto
    {
        

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