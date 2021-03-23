using Autofac;
using Domain.API.Core.Interfaces.Services;
using Domain.API.Services;
using Domain.API.Core.Interfaces.Repositories;
using Infrastructure.API.Data.Repositories;
using Application.API.Application.Interface.Mappers;
using Application.API.Application.Interface;
using Application.API.Application.Mappers;
using Application.API.Application;

namespace Infrastructure.API.Infrastructure.CrossCuting.IOC
{
    public class IOCConfiguration
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ClientServiceApplication>().As<IClientServiceApplication>();
            builder.RegisterType<ProductServiceApplication>().As<IProductServiceApplication>();
            builder.RegisterType<ClientService>().As<IClientService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ClientRepository>().As<IClientRepository>();
            builder.RegisterType<ClientMapper>().As<IClientMapper>();
            builder.RegisterType<ProductMapper>().As<IProductMapper>();

            #endregion
        }
    }
}