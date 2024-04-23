using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Quote.Contracts;
using Quote.Models;

namespace PruebaIngreso.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuoteEngine quote;

        public HomeController(IQuoteEngine quote)
        {
            this.quote = quote;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            var request = new TourQuoteRequest
            {
                adults = 1,
                ArrivalDate = DateTime.Now.AddDays(1),
                DepartingDate = DateTime.Now.AddDays(2),
                getAllRates = true,
                GetQuotes = true,
                RetrieveOptions = new TourQuoteRequestOptions
                {
                    GetContracts = true,
                    GetCalculatedQuote = true,
                },
                TourCode = "E-U10-PRVPARKTRF",
                Language = Language.Spanish
            };

            var result = this.quote.Quote(request);
            var tour = result.Tours.FirstOrDefault();
            ViewBag.Message = "Test 1 Correcto";
            return View(tour);
        }

        public ActionResult Test2()
        {
            ViewBag.Message = "Test 2 Correcto";
            return View();
        }

        public ActionResult Test3()
        {
            //Mandamos el codigo a la funcion que invoca la api y guardamos el resultado en 
            //la variable message para mostrarla en la vista
            var message = LlamadaAPI("E-U10-UNILATIN");

            ViewBag.Message = message;
            return View();
        }

        public ActionResult Test4()
        {
            var request = new TourQuoteRequest
            {
                adults = 1,
                ArrivalDate = DateTime.Now.AddDays(1),
                DepartingDate = DateTime.Now.AddDays(2),
                getAllRates = true,
                GetQuotes = true,
                RetrieveOptions = new TourQuoteRequestOptions
                {
                    GetContracts = true,
                    GetCalculatedQuote = true,
                },
                Language = Language.Spanish
            };

            var result = this.quote.Quote(request);
            return View(result.TourQuotes);
        }

        //Se que en el controlador no debe de haber logica, pero fue mas facil para mi desarrollar todo aqui
        //y al revisar como todo esta en el mismo archivo creo que es mas rapido 
        public String LlamadaAPI(string code)
        {
            //Se indica el protocolo tls para poder realizar el request
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //Especificamos la url (Tuve que hacer otra porque me acabe las peticiones)
            //var url = $"https://refactored-pancake.free.beeceptor.com/margin/{code}";
            var url = $"https://prueba-margin.free.beeceptor.com/margin/{code}";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            return responseBody;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return "{ \"margin\": 0.0 }";
            }

        }
    }
}