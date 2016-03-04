using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CommuterSystem.Models;

namespace CommuterSystem.Controllers
{
    [RoutePrefix("process")]
    public class ProcessmonitorController : ApiController
    {
        [HttpGet]
        [Route("getpmlist")]
        public IHttpActionResult getpmlist()
        {
            var list = new List<processmonitor>()
            {
              new processmonitor()
              {
                id= 1,status = "Done",desc = "dsc1" , starttime ="02/25/2016", endtime ="02/26/2016",dummy = ""
              },
              new processmonitor()
              {
                id= 2,status = "Done",desc = "dsc1" , starttime ="02/25/2016", endtime ="02/26/2016",dummy = ""
              }
              ,
              new processmonitor()
              {
                id= 3,status = "Done",desc = "dsc1" , starttime ="02/25/2016", endtime ="02/26/2016",dummy = ""
              },
              new processmonitor()
              {
                id=4,status = "Done",desc = "dsc1" , starttime ="02/25/2016", endtime ="02/26/2016",dummy = ""
              },
              new processmonitor()
              {
                id= 5,status = "Done",desc = "dsc1" , starttime ="02/25/2016", endtime ="02/26/2016",dummy = ""
              },
              new processmonitor()
              {
                id= 6,status = "Done",desc = "dsc1" , starttime ="02/25/2016", endtime ="02/26/2016",dummy = ""
              },
              new processmonitor()
              {
                id= 7,status = "Done",desc = "dsc1" , starttime ="02/25/2016", endtime ="02/26/2016",dummy = ""
              },
              new processmonitor()
              {
                id= 8,status = "Done",desc = "dsc1" , starttime ="02/25/2016", endtime ="02/26/2016",dummy = ""
              },
              new processmonitor()
              {
                id= 9,status = "Done",desc = "dsc1" , starttime ="02/25/2016", endtime ="02/26/2016",dummy = ""
              },
              new processmonitor()
              {
                id= 10,status = "Done",desc = "dsc1" , starttime ="02/25/2016", endtime ="02/26/2016",dummy = ""
              },
                new processmonitor()
              {
                id= 11,status = "Done",desc = "dsc1" , starttime ="02/25/2016", endtime ="02/26/2016",dummy = ""
              },

                };

            return Ok(list);
        }
    }
}
