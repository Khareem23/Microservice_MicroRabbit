using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Domain.Core.Commands;
using MicroRabbit.Domain.Core.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MicroRabbit.Infra.Bus
{
    // sealed is used to prevent others from Inheriting or Extending 
    // this Class 
    public sealed class RabbitMQBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;

        public RabbitMQBus(IMediator mediator)
        {
            _mediator = mediator;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }
        
        // Send 
        public  Task SendCommand<T>(T command) where T : Command
        {
           return _mediator.Send(command);
        }
        
        
        
        // Publish 

        public void publish<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var eventName = @event.GetType().Name;
                channel.QueueDeclare(eventName,false,false, false, null);
                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);
                
                channel.BasicPublish("",eventName,null,body);
            }
       
        }

        
        // Subscribe 
        
        public void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>
        {
            throw new System.NotImplementedException();
        }
    }
}