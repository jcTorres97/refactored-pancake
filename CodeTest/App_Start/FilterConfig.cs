using System.Web;
using System.Web.Mvc;
using PruebaIngreso.Models;

namespace PruebaIngreso
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorHandler()
            {
                View = "Error"
            });
        }
    }
}
