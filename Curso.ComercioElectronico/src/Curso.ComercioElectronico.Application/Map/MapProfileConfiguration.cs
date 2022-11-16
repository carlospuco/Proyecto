using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Curso.ComercioElectronico.Application.Dtos;
using Curso.ComercioElectronico.Domain;
using Curso.ComercioElectronico.Domain.Entidades;

namespace Curso.ComercioElectronico.Application.Map
{
    public class MapProfileConfiguration : Profile
    {
        public MapProfileConfiguration()
        {
            CreateMap<ClienteCrearActualizarDto, Cliente>();
            CreateMap<Cliente,ClienteDto>();
            CreateMap<ProductoCrearActualizarDto, Producto>();
            CreateMap<Producto, ProductoDto>();
            CreateMap<OrdenCrearActualizarDto, Orden>();
            CreateMap<Orden,OrdenDto>();
            CreateMap<OrdenItemCrearActualizarDto, OrdenItem>();
            CreateMap<OrdenItem,OrdenItemDto>();
            CreateMap<TipoClienteCrearActualizarDto, TipoCliente>();
            CreateMap<TipoCliente,TipoClienteDto>();
            CreateMap<CarroCrearActualizarDto, Carro>();
            CreateMap<Carro,CarroDto>();
            CreateMap<CarroItemCrearActualizarDto, CarroItem>();
            CreateMap<CarroItem,CarroItemDto>();


    
        }
    }
}