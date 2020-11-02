using System.Diagnostics.Eventing.Reader;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace CitasSAPSO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());           
        }
    }
}
