using Reservationsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.TwiML.Mvc;

namespace Reservationsystem.Controllers
{

    public class HandleUserInputController : Controller
    {
        private ReservationsystemDb db = new ReservationsystemDb();

        public ActionResult Index(int id) 
        {
            var twiml = new Twilio.TwiML.TwilioResponse();

            int user_pushed = int.Parse(Request["Digits"]);

            // user has approved the reservation
            if (user_pushed == 1)
            {
                twiml.Say("Besten Dank. Die Reservation wurde bestätigt.", new { language = "de" });

                SendSmsToUser(true);
            }
            // user has rejected the reservation
            else if (user_pushed == 2) 
            {
                twiml.Say("Besten Dank. Die Reservation wurde abgelehnt.", new { language = "de" });

                SendSmsToUser(false);
            }
            else
            {
                twiml.Say("Entschuldigen sie, diese Eingabe ist nicht möglich.");
                twiml.Redirect(string.Format("http://ardbeg.azurewebsites.net/HandleOutgoingCall/Index/{0}", id), "GET");
            }
            return new TwiMLResult(twiml);
        }

        /// <summary>
        /// Sends an SMS to the User
        /// </summary>
        public void SendSmsToUser(bool isAccepted) 
        {
            string type = (isAccepted) ? "bestätigt" : "abgelehnt";

            var text = string.Format("Deine Reservation wurde soeben {0}.", type);

            // user settings form twilio account are required
            string AccountSid = "";
            string AuthToken = "";

            var twilio = new TwilioRestClient(AccountSid, AuthToken);

            var message = twilio.SendSmsMessage("+15612216816", "heregoesyourphonenumber", text);

            if (message.RestException != null)
            {
                var error = message.RestException.Message;
                // handle the error ...
            }
        }
	}
}