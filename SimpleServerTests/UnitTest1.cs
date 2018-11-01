using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using SimpleServer.Controllers; 

namespace SimpleServerTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void SummTest1()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Summ(3, 3) as ViewResult;

            Assert.AreEqual(6, (int)result.ViewData["Result"]); 
        }

        [TestMethod]
        public void SummTest2()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Summ(0, 0) as ViewResult;

            Assert.AreEqual(0, (int)result.ViewData["Result"]); 
        }

        [TestMethod]
        public void IndexTest()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreNotEqual(result, null); 
        }
    }


}
