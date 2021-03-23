using Autofac;

namespace Infrastructure.API.Infrastructure.CrossCuting.IOC
{
    public class IOCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            IOCConfiguration.Load(builder);
        }
    }
}