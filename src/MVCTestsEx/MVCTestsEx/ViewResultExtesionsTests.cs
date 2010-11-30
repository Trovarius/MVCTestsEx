using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;

namespace MVCTestsEx
{
    [TestFixture]
    public class ViewResultExtesionsTests
    {
        [Test]
        public void testing_that_AssertViewName_passing_the_correct_viewresult_viewname_should_pass()
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "SomeName";

            viewResult.AssertViewName("SomeName");
        }
    }

    public static class MVCTestsExtensions
    {
        public static void AssertViewName(this ViewResult viewResult, string expectedViewName)
        {
            Assert.AreEqual(expectedViewName, viewResult.ViewName);
        }
    }
}
