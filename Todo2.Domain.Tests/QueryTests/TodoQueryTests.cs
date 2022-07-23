using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo2.Domain.Entities;
using Todo2.Domain.Queries;

namespace Todo2.Domain.QueryTests
{
    [TestClass]
    public class TodoQueryTest
    {
        private List<TodoItem> _items;

        public TodoQueryTest()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("tarefa 1", System.DateTime.Now, "Gabriel"));
            _items.Add(new TodoItem("tarefa 2", System.DateTime.Now, "Daniel"));
            _items.Add(new TodoItem("tarefa 3", System.DateTime.Now, "Gabriel"));
            _items.Add(new TodoItem("tarefa 4", System.DateTime.Now, "Daniel"));
            _items.Add(new TodoItem("tarefa 5", System.DateTime.Now, "Gabriel"));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Gabriel"));
            Assert.AreEqual(3, result.Count());
        }
    }
}