﻿using GFFIAdmin.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace GFFIAdmin.Controllers
{
    [RoutePrefix("gffiadmin")]
    public class GffiAdminController : ApiController
    {
        private ILobRepository ilob = null;
        private IPortfolioRepository iport = null;
        public GffiAdminController(ILobRepository _ilob , IPortfolioRepository _iport)
        {
            ilob = _ilob;
            iport = _iport;
        }

        [Route("getlob")]
        [HttpGet]
        public List<LineofBusiness> getLob()
        {
            return ilob.getLineofBusiness();
        }

        [Route("getportfolios")]
        [HttpGet]
        public List<Portfolio> getportfolios()
        {
            return iport.getPortfolios();
        }

        [Route("deleteportfolio/{id}")]
        [HttpDelete]
        public List<Portfolio>  deletePortfolio(int id)
        {
            return iport.DeletePortfolio(id);
        }


    }
}
