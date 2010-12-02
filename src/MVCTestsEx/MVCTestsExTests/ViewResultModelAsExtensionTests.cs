using System.Collections.Generic;
using System.Web.Mvc;
using MVCTestsEx;
using NUnit.Framework;

namespace MVCTestsExTests
{
    //used only to test the ModelAs<T> extension
    public class User
    {
        public string Name { get; set; }
    }

    [TestFixture]
    public class ViewResultModelAsExtensionTests
    {
        [Test]
        public void modelas_in_viewresult_with_model_user_should_not_be_null()
        {
            var viewResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new User())
                                 };

            Assert.IsNotNull(viewResult.ModelAs<User>());
        }
        [Test]
        public void modelas_in_viewresult_with_model_user_with_name_should_have_the_name()
        {
            var viewResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new User { Name = "SomeName" })
                                 };

            Assert.AreEqual("SomeName", viewResult.ModelAs<User>().Name);
        }
        [Test]
        public void modelas_in_viewresult_with_model_ienumerable_user_should_not_be_null()
        {
            var viewResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new List<User>())
                                 };

            Assert.IsNotNull(viewResult.ModelAs<IEnumerable<User>>());
        }
        [Test]
        public void modelas_in_viewresult_with_model_ilist_with_1_user_should_has_count_1()
        {
            var viewResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new List<User> { new User() })
                                 };

            Assert.AreEqual(1, viewResult.ModelAs<List<User>>().Count);
        }
        [Test]
        public void modelas_in_viewresult_with_model_ilist_with_2_user_should_has_count_2()
        {
            var viewResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new List<User> { new User(), new User() })
                                 };

            Assert.AreEqual(2, viewResult.ModelAs<List<User>>().Count);
        }
        [Test]
        public void modelas_in_viewresult_with_model_ilist_with_1_user_with_name_should_have_the_name()
        {
            var viewResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new List<User> { new User { Name = "SomeName" } })
                                 };

            Assert.AreEqual("SomeName", viewResult.ModelAs<List<User>>()[0].Name);
        }
        [Test]
        public void modelas_in_viewresult_with_model_ilist_with_2_users_second_user_with_name_should_have_the_name()
        {
            var viewResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new List<User> { new User(), new User { Name = "SomeName" } })
                                 };

            Assert.AreEqual("SomeName", viewResult.ModelAs<List<User>>()[1].Name);
        }
    }
}