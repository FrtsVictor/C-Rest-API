using Domain.API.Core.Interfaces.Repositories;
using Domain.API.Core.Interfaces.Services;
using Domain.API.Domain.Entities;

namespace Domain.API.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
            : base(productRepository)
        {
            this.productRepository = productRepository;
        }

    }
}