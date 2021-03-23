using Domain.API.Core.Interfaces.Repositories;
using Domain.API.Domain.Entities;
using Infrastructure.API.Infrastructure.Data;

namespace Infrastructure.API.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly SqlContext sqlContext;

        public ProductRepository(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}