using MediatR;

namespace Elektra.Productos.Tienda.ApplicationServices.Abstractions.Messaging
{
    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
       where TCommand : ICommand<TResponse>
    {
    }
}
