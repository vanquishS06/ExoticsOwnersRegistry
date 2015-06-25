using System.Web;
using System.Web.Mvc;

namespace ExoticsOwnersRegistry
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // Force a login to display the main page
//            filters.Add(new AuthorizeAttribute());
        }
    }
}
