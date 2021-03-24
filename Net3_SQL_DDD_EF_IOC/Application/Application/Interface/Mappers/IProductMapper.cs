using System.Collections.Generic;
using Application.API.Application.Dtos;
using Domain.API.Domain.Entities;

namespace Application.API.Application.Interface.Mappers
{
    public interface IProductMapper
    {
        Product MapperDtoEntity(ProductDto productDto);
        IEnumerable<ProductDto> MapperListProductDto(IEnumerable<Product> products);
        ProductDto MapperEntityToDto(Product product);
    }
}