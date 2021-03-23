using System.ComponentModel.Design;
using System.Collections.Generic;
using Application.API.Application.Dtos;
using Application.API.Application.Interface;
using Application.API.Application.Interface.Mappers;
using Domain.API.Core.Interfaces.Services;

namespace Application.API.Application
{
    public class ProductServiceApplication : IProductServiceApplication
    {
        private readonly IProductService productService;
        private readonly IProductMapper productMapper;
        public ProductServiceApplication(IProductService productService,
                                        IProductMapper productMapper)
        {
            this.productService = productService;
            this.productMapper = productMapper;
        }

        public void Add(ProductDto productDto)
        {
            var product = productMapper.MapperDtoEntity(productDto);
            productService.Add(product);
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var products = productService.GetAll();
            return productMapper.MapperListProductDto(products);

        }

        public ProductDto GetById(int id)
        {
            var product = productService.GetById(id);
            return productMapper.MapperEntityToDto(product);
        }

        public void Remove(ProductDto productDto)
        {
            var product = productMapper.MapperDtoEntity(productDto);
            productService.Remove(product);
        }

        public void Update(ProductDto productDto)
        {
            var product = productMapper.MapperDtoEntity(productDto);
            productService.Update(product);
        }
    }
}