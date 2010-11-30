using System.Web.Mvc;
using NUnit.Framework;

namespace MVCTestsExTests
{
    public static class MVCTestsExtensions
    {
        public static void AssertViewName(this ViewResult viewResult, string expectedViewName)
        {
            Assert.AreEqual(expectedViewName, viewResult.ViewName);
        }
    }
}