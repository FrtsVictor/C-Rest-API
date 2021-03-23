using System.Collections.Generic;
using Application.API.Application.Dtos;
using Domain.API.Domain.Entities;

namespace Application.API.Application.Interface.Mappers
{
    public interface IClientMapper
    {
        Client MapperDtoToEntity(ClientDto clientDto);
        IEnumerable<ClientDto> MapperListClientDto(IEnumerable<Client> clients);
        ClientDto MaperEntityToDto(Client client);
    }
}