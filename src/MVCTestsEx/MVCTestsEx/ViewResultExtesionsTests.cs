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
        [Test]
        public void testing_that_AssertViewName_passing_wrong_viewresult_viewname_should_not_pass()
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "SomeName";

            try
            {
                viewResult.AssertViewName("SomeWrongName");
            }
            catch (AssertionException ex)
            {
                Assert.That(Is.StringContaining("Expected: \"SomeWrongName\"").Matches(ex.Message));
                Assert.That(Is.StringContaining("But was:  \"SomeName\"").Matches(ex.Message));
            }
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
