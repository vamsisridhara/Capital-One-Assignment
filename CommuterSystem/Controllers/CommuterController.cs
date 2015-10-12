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

    }
}
