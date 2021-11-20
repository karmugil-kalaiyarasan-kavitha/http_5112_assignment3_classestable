using System.Web;
using System.Web.Mvc;

namespace http_5112_assignment3_class
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
