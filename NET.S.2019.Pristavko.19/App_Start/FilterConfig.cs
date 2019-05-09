using System.Web;
using System.Web.Mvc;

namespace NET.S._2019.Pristavko._19
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
