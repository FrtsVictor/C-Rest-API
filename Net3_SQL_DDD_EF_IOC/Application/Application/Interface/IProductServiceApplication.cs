using System.Collections.Generic;
using Application.API.Application.Dtos;

namespace Application.API.Application.Interface
{
    public interface IProductServiceApplication
    {
        void Add(ProductDto productDto);
        void Update(ProductDto productDto);
        void Remove(ProductDto productDto);
        IEnumerable<ProductDto> GetAll();
        ProductDto GetById(int id);
    }
}