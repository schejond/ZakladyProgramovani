using Lekce13;
using Moq;

namespace MyApplication.Tests
{
    public class CalculatorTests
    {
        // ukazka bezneho mocku. Namockuje se IDatabase a nastavi se, aby vracela statickou hodnotu
        [Test]
        public void Calculate_WithNoArgument_ReturnsExpectedValue()
        {
            Mock<IDatabase> databaseMock = new Mock<IDatabase>();
            databaseMock.Setup(db => db.GetData()).Returns(5);

            Calculator calc = new Calculator(databaseMock.Object);

            var result = calc.Calculate();

            Assert.AreEqual(10, result);
        }

        // namockuje se IDatabase a nastavi se, aby vracela statickou hodnotu pro jakkykoliv vstupni string
        [Test]
        public void Calculate_WithUserName_ReturnsExpectedValue()
        {
            Mock<IDatabase> databaseMock = new Mock<IDatabase>();
            databaseMock.Setup(db => db.GetUserData(It.IsAny<string>())).Returns(5);

            Calculator calc = new Calculator(databaseMock.Object);

            var result = calc.Calculate("Ondra");

            Assert.AreEqual(10, result);
        }

        // overuje, ze metoda byla zavolana prave jednou
        [Test]
        public void Calculate_CheckDatabaseGetData_MethodInvoked()
        {
            Mock<IDatabase> databaseMock = new Mock<IDatabase>();
            databaseMock.Setup(db => db.GetData()).Returns(5);

            Calculator calc = new Calculator(databaseMock.Object);

            var result = calc.Calculate();

            databaseMock.Verify(db => db.GetData(), Times.Once);
        }

        // overuje, ze metoda zpracuje exception dle ocekavani (v tetot implementaci Calculator vyjimky nehlida, takze se zpropaguje)
        [Test]
        public void Calculate_ChecksThatExceptionIsPropagatedWhenDatabaseThrows()
        {
            Mock<IDatabase> databaseMock = new Mock<IDatabase>();
            databaseMock.Setup(db => db.GetUserData(It.IsAny<string>())).Throws(new Exception("Database error"));

            Calculator calc = new Calculator(databaseMock.Object);

            Assert.Throws<Exception>(() =>
            {
                calc.Calculate("Ondra");
            });
        }
    }
}
