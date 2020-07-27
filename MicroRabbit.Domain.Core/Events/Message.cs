using MediatR;

namespace MicroRabbit.Domain.Core.Events
{
    // IRequest is from MediatR library
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }

        public Message()
        {
            // Using Reflection to get Type
            MessageType = GetType().Name;
        }
    }
}