using System.ComponentModel.Design;
using System.Collections.Generic;
using Application.API.Application.Dtos;
using Application.API.Application.Interface;
using Application.API.Application.Interface.Mappers;
using Domain.API.Core.Interfaces.Services;

namespace Application.API.Application
{
    public class ClientServiceApplication : IClientServiceApplication
    {
        private readonly IClientService clientService;
        private readonly IClientMapper clientMapper;
        public ClientServiceApplication(IClientService clientService,
                                        IClientMapper clientMapper)
        {
            this.clientService = clientService;
            this.clientMapper = clientMapper;
        }
        
        public void Add(ClientDto clientDto)
        {
            var client = clientMapper.MapperDtoToEntity(clientDto);
            clientService.Add(client);
        }

        public IEnumerable<ClientDto> GetAll()
        {
            var clients = clientService.GetAll();
            return clientMapper.MapperListClientDto(clients);
        }

        public ClientDto GetById(int id)
        {
            var client = clientService.GetById(id);
            return clientMapper.MaperEntityToDto(client);
        }

        public void Remove(ClientDto clientDto)
        {
            var client = clientMapper.MapperDtoToEntity(clientDto);
            clientService.Remove(client);
        }

        public void Update(ClientDto clientDto)
        {
            var client = clientMapper.MapperDtoToEntity(clientDto);
            clientService.Update(client);
        }
    }
}