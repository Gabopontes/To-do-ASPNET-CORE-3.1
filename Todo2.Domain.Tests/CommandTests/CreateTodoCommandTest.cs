using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo2.Domain.Commands;

namespace Todo2.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidcommand = new CreateTodoCommand("", "", System.DateTime.Now);
        private readonly CreateTodoCommand _validcommand = new CreateTodoCommand("Jogar bola", "Gabriel", System.DateTime.Now);

        [TestMethod]
        public void Dado_um_comando_invalido()
        {

            _invalidcommand.Validate();
            Assert.AreEqual(_invalidcommand.Valid, false);
        }
        [TestMethod]
        public void Dado_um_comando_valido()
        {
            _validcommand.Validate();
            Assert.AreEqual(_validcommand.Valid, true);
        }
    }
}
