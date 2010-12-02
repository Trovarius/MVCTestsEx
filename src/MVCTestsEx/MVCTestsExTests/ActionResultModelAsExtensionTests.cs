using System.Collections.Generic;
using System.Web.Mvc;
using MVCTestsEx;
using NUnit.Framework;

namespace MVCTestsExTests
{
    [TestFixture]
    public class ActionResultModelAsExtensionTests
    {
        [Test]
        public void modelas_in_actionresult_with_model_user_should_not_be_null()
        {
            ActionResult actionResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new User())
                                 };

            Assert.IsNotNull(actionResult.ModelAs<User>());
        }
        [Test]
        public void modelas_in_actionresult_with_model_user_with_name_should_have_the_name()
        {
            ActionResult actionResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new User { Name = "SomeName" })
                                 };

            Assert.AreEqual("SomeName", actionResult.ModelAs<User>().Name);
        }
        [Test]
        public void modelas_in_actionresult_with_model_ienumerable_user_should_not_be_null()
        {
            ActionResult actionResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new List<User>())
                                 };

            Assert.IsNotNull(actionResult.ModelAs<IEnumerable<User>>());
        }
        [Test]
        public void modelas_in_actionresult_with_model_ilist_with_1_user_should_has_count_1()
        {
            ActionResult actionResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new List<User> { new User() })
                                 };

            Assert.AreEqual(1, actionResult.ModelAs<List<User>>().Count);
        }
        [Test]
        public void modelas_in_actionresult_with_model_ilist_with_2_user_should_has_count_2()
        {
            ActionResult actionResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new List<User> { new User(), new User() })
                                 };

            Assert.AreEqual(2, actionResult.ModelAs<List<User>>().Count);
        }
        [Test]
        public void modelas_in_actionresult_with_model_ilist_with_1_user_with_name_should_have_the_name()
        {
            ActionResult actionResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new List<User> { new User { Name = "SomeName" } })
                                 };

            Assert.AreEqual("SomeName", actionResult.ModelAs<List<User>>()[0].Name);
        }
        [Test]
        public void modelas_in_actionresult_with_model_ilist_with_2_users_second_user_with_name_should_have_the_name()
        {
            ActionResult actionResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new List<User> { new User(), new User { Name = "SomeName" } })
                                 };

            Assert.AreEqual("SomeName", actionResult.ModelAs<List<User>>()[1].Name);
        }
    }
}