using Reservationsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.TwiML.Mvc;

namespace Reservationsystem.Controllers
{
    public class HandleOutgoingCallController : Controller
    {
        private ReservationsystemDb db = new ReservationsystemDb();

        //
        // GET: /HandleOutgoingCall/
        public ActionResult Index(int id)
        {
            //Gather nesscessary information
            var reservation = db.ReservationModels.Find(id);
            var firstName = reservation.Values.Where(x => x.Key.UniqueName == "Form_Vorname").FirstOrDefault().Data;
            var lastName = reservation.Values.Where(x => x.Key.UniqueName == "Form_Name").FirstOrDefault().Data;
            var time = reservation.Values.Where(x => x.Key.UniqueName == "Form_Zeit").FirstOrDefault().Data;
            var quantity = reservation.Values.Where(x => x.Key.UniqueName == "Form_Anzahl").FirstOrDefault().Data;
            var date = reservation.Values.Where(x => x.Key.UniqueName == "Form_Datum").FirstOrDefault().Data;

            //Create twilio markup language
            var twiml = new Twilio.TwiML.TwilioResponse();
            twiml.Say("Guten Tag. Folgende Reservation wurde soeben aufgegeben.", new { language = "de" });
            twiml.Say(string.Format("Datum: {0} ", date), new { language = "de" });
            twiml.Say(string.Format("Zeit: {0} ", time), new { language = "de" });
            twiml.Say(string.Format("Anzahl Personen: {0} ", quantity), new { language = "de" });
            twiml.Say(string.Format("Name: {0} {1} ", firstName, lastName), new { language = "de" });

            twiml.BeginGather(new
            {
                action = string.Format("http://ardbeg.azurewebsites.net/HandleUserInput/Index/{0}", id),
                numDigits = "1"
            });
            twiml.Say("Um die Reservation zu bestätigen drücken sie die 1.", new { language = "de" });
            twiml.Say("Um die Reservation abzulehnen drücken sie die 2.", new { language = "de" });
            twiml.EndGather();

            twiml.Say("Bitte entschuldigen sie, ich habe ihre Eingabe nicht verstanden.", new { language = "de" });
            twiml.Redirect(string.Format("http://ardbeg.azurewebsites.net/HandleOutgoingCall/Index/{0}", id),"GET");

            return new TwiMLResult(twiml);
        }
	}
}
