using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo2.Domain.Entities;

namespace Todo2.Domain.Tests.Entitytests
{
    [TestClass]
    public class TodoItemTest
    {
        private readonly TodoItem _validTodo = new TodoItem("Titulo", System.DateTime.Now, "Gabriel");

        [TestMethod]
        public void Dado_um_novo_Todo_o_mesmo_nao_pode_ser_comcluido()
        {
            Assert.AreEqual(_validTodo.Done, false);
        }
    }
}