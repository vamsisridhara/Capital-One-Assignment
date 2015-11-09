using GFFIAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GFFIAdmin.Controllers
{
    [RoutePrefix("gffiadmin")]
    public class GffiAdminController : ApiController
    {
        [Route("getlob")]
        public List<LineofBusiness> getLob()
        {
            ILobRepository repo = new LobRepository();
            return repo.getLineofBusiness();
        }
    }
}
