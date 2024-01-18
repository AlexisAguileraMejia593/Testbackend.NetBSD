using System.Web;
using System.Web.Mvc;

namespace Test_backend.Net_BSD
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
