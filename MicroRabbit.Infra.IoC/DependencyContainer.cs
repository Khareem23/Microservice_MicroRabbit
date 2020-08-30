using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.Interfaces;
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
            
            // Application Services Layer 
            servcies.AddTransient<IAccountService, AccountService>();
            
            // Data Layer 
            servcies.AddTransient<IAccountRepository, AccountRepository>();
            servcies.AddTransient<BankingDBContext>();
        }
    }
}