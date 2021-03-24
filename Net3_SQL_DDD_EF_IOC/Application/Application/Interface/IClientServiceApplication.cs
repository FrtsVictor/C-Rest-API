using System.Collections.Generic;
using Application.API.Application.Dtos;

namespace Application.API.Application.Interface
{
    public interface IClientServiceApplication
    
    {
        void Add(ClientDto clientDto);
        void Update(ClientDto clientDto);
        void Remove(ClientDto clientDto);
        IEnumerable<ClientDto> GetAll();
        ClientDto GetById(int id);
    }
}