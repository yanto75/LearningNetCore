using CoreEfTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace CoreEfTest.Test
{
    public class Tests
    {
        private Mock<ILogger<HomeController>> _logger;
        private HomeController _sut;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<HomeController>>(MockBehavior.Strict);
            _sut = new HomeController(_logger.Object);
        }

        [TestCase(true, "Color")]
        [TestCase(false, "Choice")]
        public void ValidUserInput_SelectionMade_ShowCorrectView(bool isColor, string expectedAction)
        {
            var actual = _sut.Choice(isColor);

            if (isColor)
            {
                Assert.That(actual, Is.InstanceOf<RedirectToActionResult>());
                var actualAsRedirect = actual as RedirectToActionResult;
                Assert.That(actualAsRedirect.ActionName, Is.EqualTo(expectedAction));
            }
            else
            {
                Assert.That(actual, Is.InstanceOf<ViewResult>());
                var actualAsRedirect = actual as ViewResult;

                //Assert.That(actual, Is.InstanceOf<ViewResult>());
                //actual.AssertActionRedirect().ToAction(expectedAction);

                //Can't use MvcContrib.TestHelper because that expects a System.Web.Mvc.Controller, and
                //I now have a Microsoft.AspNetCore.Mvc.Controller instead (from what I gather).
                Assert.That(actualAsRedirect.ViewName, Is.EqualTo(expectedAction));
            }
            
        }
    }
}