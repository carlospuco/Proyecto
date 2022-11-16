using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Curso.ComercioElectronico.Application.Dtos;
using Curso.ComercioElectronico.Application.Interfaces;
using Curso.ComercioElectronico.Domain.Entidades;
using Curso.ComercioElectronico.Domain.Repositorio;

namespace Curso.ComercioElectronico.Application.AppServices
{
    public class CarroAppService : ICarroAppService
    {
        private readonly ICarroRepository repository;
        private readonly IMapper map;

        public CarroAppService(ICarroRepository repository, IMapper map)
        {
            this.repository = repository;
            this.map = map;
        }

        public async Task<CarroDto> CreateAsync(CarroCrearActualizarDto carro)
        {
            //mapeo de DTo a la entidad 
            var carroMapeo = map.Map<Carro>(carro);
            carroMapeo = await repository.AddAsync(carroMapeo);
            var carroMapeoDto = map.Map<CarroDto>(carroMapeo);
            return carroMapeoDto;
        }

        public async Task<bool> DeleteAsync(Guid carroId)
        {

            var ordenConsulta = await repository.GetByIdAsync(carroId);
            if (ordenConsulta == null)
            {
                throw new ArgumentException($"La orden con ese: {carroId}, no exite");
            }
            repository.Delete(ordenConsulta);
            return true;
        }

        public ListaPaginada<CarroDto> GetAll(int limit = 10, int offset = 0)
        {
            var carroList = repository.GetAll();

            var carroListDto =  from p in carroList
                                select new CarroDto(){
                                    Id = p.Id,
                                    CantidadProductos = p.CantidadProductos,                             
                                    ClienteId=p.ClienteId,
                                    Cliente=p.Cliente,
                                };
            var listaPag = new ListaPaginada<CarroDto>();
            listaPag.Lista=carroListDto.ToList();
            listaPag.Total=carroListDto.ToList().Count();
            return listaPag;
        }

        public ListaPaginada<CarroDto> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "")
        {
            var carroList = repository.GetAllIncluding(x=>x.Cliente);


            var carroListDto =  from p in carroList
                                select new CarroDto(){
                                    Id = p.Id,
                                    CantidadProductos = p.CantidadProductos,                               
                                    ClienteId=p.ClienteId,
                                    Cliente=p.Cliente,
                                    
                                };
            var listaPag = new ListaPaginada<CarroDto>();
            listaPag.Lista=carroListDto.ToList();
            listaPag.Total=carroListDto.ToList().Count();
            return listaPag;
        }

        public async Task UpdateAsync(Guid id, CarroCrearActualizarDto orden)
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