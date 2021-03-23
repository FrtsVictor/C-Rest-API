using Domain.API.Core.Interfaces.Repositories;
using Domain.API.Core.Interfaces.Services;
using Domain.API.Domain.Entities;

namespace Domain.API.Services
{
    public class ClientService : BaseService<Client>, IClientService
    {
        private readonly IClientRepository clientRepository;

        public ClientService(IClientRepository clientRepository) : base(clientRepository)
        {
            this.clientRepository = clientRepository;
        }
    }
}