using CommuterSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommuterSystem.Controllers
{
    [RoutePrefix("commute")]
    public class CommuterController : ApiController
    {
        [HttpGet]
        [Route("getServiceStatus")]
        public List<Routes> getServiceStatus()
        {
            return StaticData.getServiceStatus();
        }

        [HttpGet]
        [Route("getLines")]
        public List<string> getLines()
        {
            return StaticData.getLines();
        }

        [HttpGet]
        [Route("gettrains/{lineid}")]
        public List<Trips> gettrains(string lineid)
        {
            List<Trips> lstTrips = null;
            if (LineType.Silver.ToString() == lineid)
            {
                lstTrips = StaticData.getSilverTrains();
            }
            else if (LineType.Orange.ToString() == lineid)
            {
                lstTrips = StaticData.getOrangeTrains();
            }
            return lstTrips;
        }

        [HttpGet]
        [Route("getnexttrains/{stationname}")]
        public string getnexttrains(string stationname)
        {
            return StaticData.getNextTrain(stationname);
        }

        [HttpGet]
        [Route("getstationnames")]
        public List<Stations> getStationNames()
        {
            return StaticData.getStations();
        }

        [HttpPost]
        [Route("placeGPSOrders")]
        public IHttpActionResult PlaceOrders(GPSUnitOrderViewModel gpsUnitOrderViewModel)
        {
            IHttpActionResult response = null;
            try
            {
                //check whether the stock exists
                //If stock exists,  we are good with proceeding for next steps
                //capture the billing address, shipping address
                //proceed for the payment to collect the credit / debit card info
                //If payment is successful, send the acknowledgement to the UI.
                //send the tracking number to an email for notification
            }
            catch (Exception exception)
            {

                throw;
            }

            return response;
        }
    }
    public class GPSUnitOrderViewModel
    {
        public string Description { get; set; }
        public string ModelNumber { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public bool StockAvaialable { get; set; }
        public string TrackingDetails { get; set; }
        public DateTime orderPlaced { get; set; }
        public ShippingAddress shippingAddress { get; set; }
        public BillingAddress billingAddress { get; set; }
    }
    public class Address
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

    }
    public class ShippingAddress : Address
    {

    }
    public class BillingAddress : Address { }
    public class PaymentModel
    {
        public bool IsCredit { get; set; }
        public bool IsDebit { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CVV { get; set; }
    }
}
