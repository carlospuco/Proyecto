using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Curso.ComercioElectronico.Domain;
using Curso.ComercioElectronico.Domain.Entidades;

namespace Curso.ComercioElectronico.Application.Dtos
{
    public class OrdenItemDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public DateTime? FechaEmsion { get; set; }
        [Required]
        public int CatidadItems { get; set; }
        [Required]
        public Guid OrdenId { get; set; }
        [Required]
        public Orden Orden  { get; set; }

        
    }
}