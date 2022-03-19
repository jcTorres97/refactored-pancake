using System.Web.Mvc;

namespace PruebaIngreso.Models
{
    public class ErrorHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
        }
    }
}