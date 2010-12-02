using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MVCTestsEx;
using NUnit.Framework;

namespace MVCTestsExTests
{
    [TestFixture]
    public class ModelAsExtensionTests
    {
        [Test]
        public void testing_that_modelas_in_viewresult_with_model_user_should_not_be_null()
        {
            var viewResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new User())
                                 };

            Assert.IsNotNull(viewResult.ModelAs<User>());
        }
        [Test]
        public void testing_that_modelas_in_viewresult_with_model_user_with_name_should_have_the_name()
        {
            var viewResult = new ViewResult
                                 {
                                     ViewData = new ViewDataDictionary(new User { Name = "SomeName" })
                                 };

            Assert.AreEqual("SomeName", viewResult.ModelAs<User>().Name);
        }
        [Test]
        public void testing_that_modelas_in_viewresult_with_model_ienumerable_user_should_not_be_null()
        {
            var viewResult = new ViewResult
            {
                ViewData = new ViewDataDictionary(new List<User>())
            };

            Assert.IsNotNull(viewResult.ModelAs<IEnumerable<User>>());
        }
        [Test]
        public void testing_that_modelas_in_viewresult_with_model_ilist_with_1_user_should_has_count_1()
        {
            var viewResult = new ViewResult
            {
                ViewData = new ViewDataDictionary(new List<User> { new User() })
            };

            Assert.AreEqual(1, viewResult.ModelAs<List<User>>().Count);
        }
    }

    public class User
    {
        public string Name { get; set; }
    }
}
