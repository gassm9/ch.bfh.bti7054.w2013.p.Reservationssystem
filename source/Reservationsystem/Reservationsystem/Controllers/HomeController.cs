using Reservationsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reservationsystem.Controllers
{
    public class HomeController : Controller
    {
        ReservationsystemDb _db = new ReservationsystemDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Erfahren sie alles über das Reservationssystem.";

            Uri cleanedUri = new Uri(Request.Url.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Port, UriFormat.UriEscaped));
            string baseUri = cleanedUri.AbsoluteUri.Remove(cleanedUri.AbsoluteUri.Length - cleanedUri.Segments.Last().Length);

            Response.Write(baseUri);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Nehmen sie Kontakt mit uns auf.";

            return View();
        }

    }
}