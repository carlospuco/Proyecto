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
    public class CarroItemAppService : ICarroItemAppService
    
    {
        private readonly ICarroItemRepository repository;
        private readonly IMapper map;

        public CarroItemAppService(ICarroItemRepository repository, IMapper map)
        {
            this.repository = repository;
            this.map = map;
        }
        public async Task<CarroItemDto> CreateAsync(CarroItemCrearActualizarDto carro)
        {
            var carroMapeo = map.Map<CarroItem>(carro);
            carroMapeo = await repository.AddAsync(carroMapeo);
            var carroMapeoDto = map.Map<CarroItemDto>(carroMapeo);
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

        public ListaPaginada<CarroItemDto> GetAll(int limit = 10, int offset = 0)
        {
            var carroList = repository.GetAll();

            var carroListDto =  from p in carroList
                                select new CarroItemDto(){
                                    Id = p.Id,                            
                                    CarroId = p.CarroId,
                                    Carro = p.Carro,
                                    ProductoId = p.ProductoId,
                                    Producto = p.Producto
                                };
            var listaPag = new ListaPaginada<CarroItemDto>();
            listaPag.Lista=carroListDto.ToList();
            listaPag.Total=carroListDto.ToList().Count();
            return listaPag;
        }

        public ListaPaginada<CarroItemDto> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "")
        {
            var carroList = repository.GetAllIncluding(x=>x.Carro, x=>x.Producto);


            var carroListDto =  from p in carroList
                                select new CarroItemDto(){
                                    Id = p.Id,                            
                                    CarroId = p.CarroId,
                                    Carro = p.Carro,
                                    ProductoId = p.ProductoId,
                                    Producto = p.Producto
                                    
                                };
            var listaPag = new ListaPaginada<CarroItemDto>();
            listaPag.Lista=carroListDto.ToList();
            listaPag.Total=carroListDto.ToList().Count();
            return listaPag;
        }

        public async  Task UpdateAsync(Guid id, CarroItemCrearActualizarDto carro)
        {
            var ordenUpdate = await repository.GetByIdAsync(id);
            if (ordenUpdate == null){
                throw new ArgumentException($"La orden con el id: {id}, no existe");
            }
            
            //Mapeo Dto => Entidad
            map.Map(carro,ordenUpdate);

            //Persistencia objeto
            await repository.UpdateAsync(ordenUpdate);
            //await unitOfWork.SaveChangesAsync();

            return;
        }
    }
}