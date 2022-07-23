using Todo2.Domain.Commands.Contracts;

namespace Todo2.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}