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
    public class OrdenAppService : IOrdenAppservice
    {
        private IOrdenRepository repository;
        private IMapper map;

        public OrdenAppService(IOrdenRepository repository, IMapper map)
        {
        this.repository = repository;
        this.map = map;
        }


        public async Task<OrdenDto> CreateAsync(OrdenCrearActualizarDto orden)
        {
            var ordenMapeo = map.Map<Orden>(orden);
            ordenMapeo = await repository.AddAsync(ordenMapeo);
            var ordenMapeoDto = map.Map<OrdenDto>(ordenMapeo);
            return ordenMapeoDto;
        }

        public async Task<bool> DeleteAsync(Guid ordenId)
        {
            var ordenConsulta = await repository.GetByIdAsync(ordenId);
            if (ordenConsulta == null)
            {
                throw new ArgumentException($"La orden con ese: {ordenId}, no exite");
            }

            repository.Delete(ordenConsulta);
            return true;
        }

        public ListaPaginada<OrdenDto> GetAll(int limit = 10, int offset = 0)
        {
            var ordenList = repository.GetAll();

            var ordenListDto =  from m in ordenList
                                select new OrdenDto(){
                                    Id = m.Id,
                                    Nombre = m.Nombre
                                };
            var listaPag = new ListaPaginada<OrdenDto>();
            listaPag.Lista=ordenListDto.ToList();
            listaPag.Total=ordenListDto.ToList().Count();
            return listaPag;
        }

        public ListaPaginada<OrdenDto> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "")
        {
            var ordenList = repository.GetByText(limit,offset,campo,parametro).ToList();


            var ordenListDto =  from p in ordenList
                                select new OrdenDto(){
                                    Id = p.Id,
                                    Nombre = p.Nombre,
                                    FechaEmicion = p.FechaEmicion,
                                    NumeroProductos = p.NumeroProductos,                                
                                    ClienteId=p.ClienteId,
                                    Cliente=p.Cliente,
                                    
                                };
            var listaPag = new ListaPaginada<OrdenDto>();
            listaPag.Lista=ordenListDto.ToList();
            listaPag.Total=ordenListDto.ToList().Count();
            return listaPag;
        }

        public async Task UpdateAsync(Guid id, OrdenCrearActualizarDto orden)
        {
            var ordenUpdate = await repository.GetByIdAsync(id);
            if (ordenUpdate == null){
                throw new ArgumentException($"La orden con el id: {id}, no existe");
            }
            
            //Mapeo Dto => Entidad
            map.Map(orden,ordenUpdate);

            //Persistencia objeto
            await repository.UpdateAsync(ordenUpdate);
            //await unitOfWork.SaveChangesAsync();

            return;
        }
    }
}