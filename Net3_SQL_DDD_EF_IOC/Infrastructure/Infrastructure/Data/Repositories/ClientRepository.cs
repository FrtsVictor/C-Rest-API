using Domain.API.Core.Interfaces.Repositories;
using Domain.API.Domain.Entities;
using Infrastructure.API.Infrastructure.Data;

namespace Infrastructure.API.Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {

        private readonly SqlContext sqlContext;

        public ClientRepository(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }

    }
}