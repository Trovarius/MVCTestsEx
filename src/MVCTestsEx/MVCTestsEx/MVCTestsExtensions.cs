using System.Web.Mvc;
using NUnit.Framework;

namespace MVCTestsEx
{
    public static class MVCTestsExtensions
    {
        public static void AssertViewName(this ViewResult viewResult, string expectedViewName)
        {
            Assert.AreEqual(expectedViewName, viewResult.ViewName);
        }
    }
}