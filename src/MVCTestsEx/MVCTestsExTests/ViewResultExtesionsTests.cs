using System.Web.Mvc;
using MVCTestsEx;
using NUnit.Framework;

namespace MVCTestsExTests
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
        [Test]
        public void testing_that_AssertViewName_passing_null_viewresult_viewname_should_not_pass()
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = null;

            try
            {
                viewResult.AssertViewName("SomeName");
            }
            catch (AssertionException ex)
            {
                Assert.That(Is.StringContaining("Expected: \"SomeName\"").Matches(ex.Message));
                Assert.That(Is.StringContaining("But was:  <string.Empty>").Matches(ex.Message));
            }
        }
        [Test]
        public void testing_that_AssertViewName_passing_emptystring_viewresult_viewname_should_not_pass()
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = string.Empty;

            try
            {
                viewResult.AssertViewName("SomeName");
            }
            catch (AssertionException ex)
            {
                Assert.That(Is.StringContaining("Expected: \"SomeName\"").Matches(ex.Message));
                Assert.That(Is.StringContaining("But was:  <string.Empty>").Matches(ex.Message));
            }
        }
    }
}
