using System.Web.Mvc;
using MVCTestsEx;
using NUnit.Framework;

namespace MVCTestsExTests
{
    [TestFixture]
    public class ActionResultExtesionsTests
    {
        [Test]
        public void testing_that_AssertViewName_passing_the_correct_actionresult_viewname_should_pass()
        {
            var viewResult = new ViewResult();
            viewResult.ViewName = "SomeName";
            var actionResult = viewResult as ActionResult;

            actionResult.AssertViewName("SomeName");
        }
        [Test]
        public void testing_that_AssertViewName_passing_wrong_actionresult_viewname_should_not_pass()
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "SomeName";
            var actionResult = viewResult as ActionResult;

            try
            {
                actionResult.AssertViewName("SomeWrongName");
            }
            catch (AssertionException ex)
            {
                Assert.That(Is.StringContaining("Expected: \"SomeWrongName\"").Matches(ex.Message));
                Assert.That(Is.StringContaining("But was:  \"SomeName\"").Matches(ex.Message));
            }
        }
        [Test]
        public void testing_that_AssertViewName_passing_null_actionresult_viewname_should_not_pass()
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = null;
            var actionResult = viewResult as ActionResult;
            try
            {
                actionResult.AssertViewName("SomeName");
            }
            catch (AssertionException ex)
            {
                Assert.That(Is.StringContaining("Expected: \"SomeName\"").Matches(ex.Message));
                Assert.That(Is.StringContaining("But was:  <string.Empty>").Matches(ex.Message));
            }
        }
        [Test]
        public void testing_that_AssertViewName_passing_emptystring_actionresult_viewname_should_not_pass()
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = string.Empty;
            var actionResult = viewResult as ActionResult;

            try
            {
                actionResult.AssertViewName("SomeName");
            }
            catch (AssertionException ex)
            {
                Assert.That(Is.StringContaining("Expected: \"SomeName\"").Matches(ex.Message));
                Assert.That(Is.StringContaining("But was:  <string.Empty>").Matches(ex.Message));
            }
        }
    }
}
