using Flunt.Notifications;
using Todo2.Domain.Commands;
using Todo2.Domain.Commands.Contracts;
using Todo2.Domain.Entities;
using Todo2.Domain.Handlers.Contracts;
using Todo2.Domain.Repositories;

namespace Todo2.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>

    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                        false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            //Criar um Todo
            var todo = new TodoItem(command.Title, command.Date, command.User);

            //Salvar no banco
            _repository.Create(todo);

            //Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva com sucesso!", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                        false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            //Pega o Todo do banco
            var todo = _repository.GetById(command.Id, command.User);

            //Altera o Item do Todo
            todo.UpdateTitle(command.Title);

            //Salvar no banco
            _repository.Update(todo);

            //Retorna o resultado
            return new GenericCommandResult(true, "Tarefa atualizada com sucesso!", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                        false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            //Pega o Todo do banco
            var todo = _repository.GetById(command.Id, command.User);

            //Altera o Item do Todo
            todo.MarkAsDone();

            //Salvar no banco
            _repository.Update(todo);

            //Retorna o resultado
            return new GenericCommandResult(true, "Tarefa atualizada com sucesso!", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                        false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            //Pega o Todo do banco
            var todo = _repository.GetById(command.Id, command.User);

            //Altera o Item do Todo
            todo.MaskAsUndone();

            //Salvar no banco
            _repository.Update(todo);

            //Retorna o resultado
            return new GenericCommandResult(true, "Tarefa atualizada com sucesso!", todo);
        }
    }
}