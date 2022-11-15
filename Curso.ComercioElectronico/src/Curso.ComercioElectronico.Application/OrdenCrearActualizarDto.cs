using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application
{
    public class OrdenCrearActualizarDto
    {
        
        [Required]
        [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
        public string Nombre { get; set; }
        [Required]
        public DateTime? FechaEmicion { get; set; }
        [Required]
        public int NumeroProductos { get; set; }

        [Required]
        //[ForeignKey("Marca")]
        //EntidadId. Clave F. A la entidad 
        public Guid ClienteId { get; set; }


    
    }
}