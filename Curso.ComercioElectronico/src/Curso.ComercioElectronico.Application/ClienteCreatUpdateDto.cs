using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application
{
    public class ClienteCrearActualizarDto
    {
        [Required]
        [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
        public string Nombre { get; set; }

        [Required]
        public string Correo { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public Guid TipoClienteId { get; set; }
    }
}