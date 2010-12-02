using System.Web.Mvc;

namespace MVCTestsEx
{
    public static class Models
    {
        public static T ModelAs<T>(this ViewResult viewResult) where T : class
        {
            return viewResult.ViewData.Model as T;
        }
    }
}