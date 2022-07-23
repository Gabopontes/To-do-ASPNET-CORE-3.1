using System;
using System.Collections.Generic;
using Todo2.Domain.Entities;
using Todo2.Domain.Repositories;

namespace Todo2.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {

        }

        public IEnumerable<TodoItem> GetAll(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllDone(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllUndone(string email)
        {
            throw new NotImplementedException();
        }

        public TodoItem GetById(Guid id, string email)
        {
            return new TodoItem("Titulo aqui", DateTime.Now, "usuario aqui");
        }

        public IEnumerable<TodoItem> GetByPeriod(string email, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem todo)
        {

        }
    }
}