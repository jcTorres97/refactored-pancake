using System.Net;
using System.Web.Mvc;

namespace PruebaIngreso.Controllers
{
    public class ErrorController :Controller
    {
        public ActionResult Index()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View("Error");
        }
    }
}