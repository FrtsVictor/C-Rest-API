using System.Collections.Generic;
using System.Linq;
using Application.API.Application.Dtos;
using Application.API.Application.Interface.Mappers;
using Domain.API.Domain.Entities;

namespace Application.API.Application.Mappers
{
    public class ClientMapper : IClientMapper
    {
        public Client MapperDtoToEntity(ClientDto clientDto)
        {
            var client = new Client()
            {
                Id = clientDto.Id,
                Name = clientDto.Name,
                LastName = clientDto.LastName,
                Email = clientDto.Email,
                Username = clientDto.Username,
                Password = clientDto.Password
            };
            return client;
        }

        public ClientDto MaperEntityToDto(Client client)
        {
            var clientDto = new ClientDto()
            {
                Id = client.Id,
                Name = client.Name,
                LastName = client.LastName,
                Email = client.Email,
                Username = client.Username,
                Password = client.Password
            };
            return clientDto;
        }

        public IEnumerable<ClientDto> MapperListClientDto(IEnumerable<Client> clients)
        {
            var dto = clients.Select(c => new ClientDto
            {
                Id = c.Id,
                Name = c.Name,
                LastName = c.LastName,
                Email = c.Email,
                Username = c.Username,
                Password = c.Password
            });
            return dto;
        }
    }
}