using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection servcies)
        {
            // Domain Bus : registering interfaces & it's implementations 
            servcies.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}