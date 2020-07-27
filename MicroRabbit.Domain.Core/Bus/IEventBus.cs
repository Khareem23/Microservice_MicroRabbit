using System;
using System.Threading.Tasks;
using MicroRabbit.Domain.Core.Commands;
using MicroRabbit.Domain.Core.Events;

namespace MicroRabbit.Domain.Core.Bus
{
    public interface IEventBus
    {
    
        Task SendCommand<T>(T command) where T : Command;
       
       // to use reserved keyword as a variable , add @ sign in front of it . 
       void publish<T>(T @event) where T : Event;
       
       // TH defined the Handler for Event type T 
       void Subscribe<T, TH>()
           where T : Event
           where TH : IEventHandler<T>;
    }
}