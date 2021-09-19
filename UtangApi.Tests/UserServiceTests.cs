using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pera.UtangApi.Services.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        [TestMethod()]
        public void ValidateCredentialsTest()
        {
            UserService _userService = new UserService();
            bool actual = _userService.ValidateCredentials("demo", "demo");
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}