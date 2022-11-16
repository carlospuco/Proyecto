using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Curso.ComercioElectronico.Application.Dtos;
using Curso.ComercioElectronico.Application.Interfaces;
using Curso.ComercioElectronico.Domain.Entidades;
using Curso.ComercioElectronico.Domain.Repositorio;

namespace Curso.ComercioElectronico.Application.AppServices
{
    public class OrdenItemAppService : IOrdenItemAppService
    {
        private readonly IOrdenItemRepository repository;
        private IMapper map;

        public OrdenItemAppService(IOrdenItemRepository repository, IMapper map)
        {
            this.repository = repository;
            this.map = map;
        }

        public async Task<OrdenItemDto> CreateAsync(OrdenItemCrearActualizarDto ordenItem)
        {
            var ordenItemMapeo = map.Map<OrdenItem>(ordenItem);
            ordenItemMapeo = await repository.AddAsync(ordenItemMapeo);
            var ordenItemMapeoDto = map.Map<OrdenItemDto>(ordenItemMapeo);
            return ordenItemMapeoDto;
        }

        public async Task<bool> DeleteAsync(Guid ordenItemId)
        {
            var ordenItemConsulta = await repository.GetByIdAsync(ordenItemId);
            if (ordenItemConsulta == null)
            {
                throw new ArgumentException($"La Item en esa orden con ese: {ordenItemId}, no exite");
            }

            repository.Delete(ordenItemConsulta);
            return true;
        }

        public ListaPaginada<OrdenItemDto> GetAll(int limit = 10, int offset = 0)
        {
            var ordenItemList = repository.GetAll();

            var productoList = repository.GetAllIncluding(x => x.Orden);

            foreach (var iterP in productoList)
            {
                System.Console.WriteLine(JsonSerializer.Serialize(iterP));
            }

            var ordenItemListDto = from p in ordenItemList
                                    select new OrdenItemDto()
                                    {
                                        Id = p.Id,
                                        Nombre = p.Nombre,
                                        Descripcion = p.Descripcion,
                                        FechaEmsion = p.FechaEmsion,
                                        CatidadItems = p.CatidadItems,
                                        OrdenId = p.OrdenId,
                                        Orden = p.Orden

                                    };
            var listaPag = new ListaPaginada<OrdenItemDto>();
            listaPag.Lista = ordenItemListDto.ToList();
            listaPag.Total = ordenItemListDto.ToList().Count();
            return listaPag;
        }

        public ListaPaginada<OrdenItemDto> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "")
        {
            var ordenItemList = repository.GetByText(limit, offset, campo, parametro).ToList();


            var ordenItemListDto = from p in ordenItemList
                                   select new OrdenItemDto()
                                   {
                                       Id = p.Id,
                                       Nombre = p.Nombre,
                                       Descripcion = p.Descripcion,
                                       FechaEmsion = p.FechaEmsion,
                                       CatidadItems = p.CatidadItems,
                                       OrdenId = p.OrdenId,
                                       Orden = p.Orden

                                   };
            var listaPag = new ListaPaginada<OrdenItemDto>();
            listaPag.Lista = ordenItemListDto.ToList();
            listaPag.Total = ordenItemListDto.ToList().Count();
            return listaPag;
        }

        public async Task UpdateAsync(Guid id, OrdenItemCrearActualizarDto ordenItem)
        {
            var ordenItemUpdate = await repository.GetByIdAsync(id);
            if (ordenItemUpdate == null)
            {
                throw new ArgumentException($"La item de esa orden con el id: {id}, no existe");
            }

            //Mapeo Dto => Entidad
            map.Map(ordenItem, ordenItemUpdate);

            //Persistencia objeto
            await repository.UpdateAsync(ordenItemUpdate);
            //await unitOfWork.SaveChangesAsync();

            return;
        }
    }
}