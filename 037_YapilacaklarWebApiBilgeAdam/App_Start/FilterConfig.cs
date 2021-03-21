using System.Web;
using System.Web.Mvc;

namespace _037_YapilacaklarWebApiBilgeAdam
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
