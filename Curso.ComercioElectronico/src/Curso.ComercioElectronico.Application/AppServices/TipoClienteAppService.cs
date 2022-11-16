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
    public class TipoClienteAppService : ITipoClienteAppService
    {
        private readonly ITipoClienteRepository repository;
        private readonly IMapper map;

        public TipoClienteAppService(ITipoClienteRepository repository, IMapper map)
        {
            this.repository = repository;
            this.map = map;
        }

        public async Task<TipoClienteDto> CreateAsync(TipoClienteCrearActualizarDto clienteTipo)
        {
            var clienteConsulta = await repository.ExisteNombre(clienteTipo.Nombre);
            if (clienteConsulta == true)
            {
                throw new ArgumentException($"La cliente con el nombre: {clienteTipo.Nombre}, ya existe");
            }
            //mapeo de DTo a la entidad 
            var clienteMapeo = map.Map<TipoCliente>(clienteTipo);
            clienteMapeo = await repository.AddAsync(clienteMapeo);
            var clienteMapeoDto = map.Map<TipoClienteDto>(clienteMapeo);
            return clienteMapeoDto;

        }

        public async Task<bool> DeleteAsync(Guid clienteTipoId)
        {
            var clienteConsulta = await repository.GetByIdAsync(clienteTipoId);
            if (clienteConsulta == null)
            {
                throw new ArgumentException($"La cliente con ese: {clienteTipoId}, no exite");
            }

            repository.Delete(clienteConsulta);
            return true;
        }


        public ListaPaginada<TipoClienteDto> GetAll(int limit = 10, int offset = 0)
        {
            var clienteList = repository.GetAll();

            var clienteListDto = from m in clienteList
                                select new TipoClienteDto()
                                {
                                    Id = m.Id,
                                    Nombre = m.Nombre,
                                    TipoEntidadCliente = m.TipoEntidadCliente,
                                    NumeroCuentaAhorro = m.NumeroCuentaAhorro,
                                    NumeroCuentaCorriente = m.NumeroCuentaCorriente
                                };
            
            var listaPag = new ListaPaginada<TipoClienteDto>();
            listaPag.Lista = clienteListDto.ToList();
            listaPag.Total = clienteListDto.ToList().Count();
            return listaPag;
        }
        

        public ListaPaginada<TipoClienteDto> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "")
        {
            var clienteList = repository.GetAll();

            var clienteListDto = from m in clienteList
                                select new TipoClienteDto()
                                {
                                    Id = m.Id,
                                    Nombre = m.Nombre,
                                    TipoEntidadCliente = m.TipoEntidadCliente,
                                    NumeroCuentaAhorro = m.NumeroCuentaAhorro,
                                    NumeroCuentaCorriente = m.NumeroCuentaCorriente
                                };
            
            var listaPag = new ListaPaginada<TipoClienteDto>();
            listaPag.Lista = clienteListDto.ToList();
            listaPag.Total = clienteListDto.ToList().Count();
            return listaPag;
        }

        public async Task UpdateAsync(Guid id, TipoClienteCrearActualizarDto clienteTipo)
        {
            var clienteUpdate = await repository.GetByIdAsync(id);
            if (clienteUpdate == null){
                throw new ArgumentException($"La producto con el id: {id}, no existe");
            }
            

            //Mapeo Dto => Entidad
            //No crea uno nuevo (de donde viene, destino)
            map.Map(clienteTipo,clienteUpdate);
            //Persistencia objeto
            await repository.UpdateAsync(clienteUpdate);
            //await unitOfWork.SaveChangesAsync();

            return;
        }

      
    }
 }
