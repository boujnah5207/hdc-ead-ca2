using System.Web;
using System.Web.Mvc;

namespace CA_Mini_Project_V4
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}