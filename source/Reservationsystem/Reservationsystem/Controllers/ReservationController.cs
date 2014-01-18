using Reservationsystem.Models;
using Reservationsystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;

namespace Reservationsystem.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class ReservationController : Controller
    {
        private ReservationsystemDb db = new ReservationsystemDb();

        // GET: /ReservationForm/5
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemplateModel template = db.Templates.Find(id);
            if (template == null)
            {
                return HttpNotFound();
            }

            ReservationModel reservationModel = new ReservationModel();
            reservationModel.Template = template;

            return View(reservationModel);
        }

        [HttpPost]
        public ActionResult Index(int id, List<KeyValue> keyValues)
        {
            TemplateModel template = db.Templates.Find(id);
            ReservationModel reservationModel = new ReservationModel();
            reservationModel.Template = template;

            db.ReservationModels.Add(reservationModel);
            db.SaveChanges();

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var keyValue in keyValues)
                    {
                        ValueModel item = new ValueModel();

                        item.Key = db.KeyModels.Find(keyValue.Key);
                        item.Data = keyValue.Value;
                        item.Reservation = reservationModel;

                        if (item != null)
                        {
                            db.ValueModels.Add(item);
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                //redirect to confirm site
                return RedirectToAction("Confirm", new { id = reservationModel.Id });
            }

            return View(reservationModel);
        }

        public ActionResult Confirm(int id)
        {
            // user settings form twilio account are required
            string accountSid = "";
            string authToken = "";

            // phone number you have previously validated with Twilio
            string phonenumber = "+15612216816";

            // Instantiate a new Twilio Rest Client
            var client = new TwilioRestClient(accountSid, authToken);
            // add some options to rest client
            var options = new CallOptions();
            options.Url = string.Format("http://ardbeg.azurewebsites.net/HandleOutgoingCall/Index/{0}", id);
            // to test, this could be a hardcoded number
            options.To = "";
            options.From = phonenumber;
            options.Method = "GET";
            var call = client.InitiateOutboundCall(options);

            if (call.RestException != null)
            {
                throw new Exception(call.RestException.Message);
            }

            return View();
        }
    }
}
