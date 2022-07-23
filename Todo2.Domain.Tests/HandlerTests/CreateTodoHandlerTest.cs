using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo2.Domain.Commands;
using Todo2.Domain.Handlers;
using Todo2.Domain.Tests.Repositories;

namespace Todo2.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidcommand = new CreateTodoCommand("", "", System.DateTime.Now);
        private readonly CreateTodoCommand _validcommand = new CreateTodoCommand("Jogar bola", "Gabriel", System.DateTime.Now);
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execução()
        {
            var result = (GenericCommandResult)_handler.Handle(_invalidcommand);
            Assert.AreEqual(result.Success, false);
        }
        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_o_Todo()
        {
            var result = (GenericCommandResult)_handler.Handle(_validcommand);
            Assert.AreEqual(result.Success, true);
        }
    }
}
