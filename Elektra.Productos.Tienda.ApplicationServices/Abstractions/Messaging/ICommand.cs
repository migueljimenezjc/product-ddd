using MediatR;

namespace Elektra.Productos.Tienda.ApplicationServices.Abstractions.Messaging
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {
    }
}
