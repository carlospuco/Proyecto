using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Curso.ComercioElectronico.Domain;

namespace Curso.ComercioElectronico.Application
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository repository;
        private readonly IMapper map;

        public ClienteAppService(IClienteRepository repository, IMapper map)
        {
            this.repository = repository;
            this.map = map;
        }

        public async Task<ClienteDto> CreateAsync(ClienteCrearActualizarDto cliente)
        {
            var clienteConsulta = await repository.ExisteNombre(cliente.Nombre);
            if (clienteConsulta == true)
            {
                throw new ArgumentException($"La cliente con el nombre: {cliente.Nombre}, ya existe");
            }
            //mapeo de DTo a la entidad 
            var clienteMapeo = map.Map<Cliente>(cliente);
            clienteMapeo = await repository.AddAsync(clienteMapeo);
            var clienteMapeoDto = map.Map<ClienteDto>(clienteMapeo);
            return clienteMapeoDto;

        }

        public async Task<bool> DeleteAsync(Guid clienteId)
        {
            var clienteConsulta = await repository.GetByIdAsync(clienteId);
            if (clienteConsulta == null)
            {
                throw new ArgumentException($"La cliente con ese: {clienteId}, no exite");
            }

            repository.Delete(clienteConsulta);
            return true;
        }

        public ListaPaginada<ClienteDto> GetAll(int limit = 10, int offset = 0)
        {

            var clienteList = repository.GetAll();

            var clienteListDto = from m in clienteList
                                select new ClienteDto()
                                {
                                    Id = m.Id,
                                    Nombre = m.Nombre,
                                    Correo = m.Correo,
                                    Direccion = m.Direccion,
                                    TipoCliente = m.TipoCliente
                                };
            
            var listaPag = new ListaPaginada<ClienteDto>();
            listaPag.Lista = clienteListDto.ToList();
            listaPag.Total = clienteListDto.ToList().Count();
            return listaPag;
        }


        public ListaPaginada<ClienteDto> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "")
        {
            var clienteList = repository.GetAll();

            var clienteListDto = from m in clienteList
                                select new ClienteDto()
                                {
                                    Id = m.Id,
                                    Nombre = m.Nombre,
                                    Correo = m.Correo,
                                    Direccion = m.Direccion,
                                    TipoClienteId = m.TipoClienteId,
                                    TipoCliente = m.TipoCliente
                                    
                                };
            
            var listaPag = new ListaPaginada<ClienteDto>();
            listaPag.Lista = clienteListDto.ToList();
            listaPag.Total = clienteListDto.ToList().Count();
            return listaPag;
        }

        public async Task UpdateAsync(Guid id, ClienteCrearActualizarDto cliente)
        {
            var clienteUpdate = await repository.GetByIdAsync(id);
            if (clienteUpdate == null){
                throw new ArgumentException($"La producto con el id: {id}, no existe");
            }
            

            //Mapeo Dto => Entidad
            //No crea uno nuevo (de donde viene, destino)
            map.Map(cliente,clienteUpdate);
            //Persistencia objeto
            await repository.UpdateAsync(clienteUpdate);
            //await unitOfWork.SaveChangesAsync();

            return;
        }

    }
    }