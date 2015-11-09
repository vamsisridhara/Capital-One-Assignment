using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GFFIAdmin.Models
{
    public class LobRepository : ILobRepository
    {
        public List<LineofBusiness> getLineofBusiness()
        {
            return new List<LineofBusiness>()
            {
                new LineofBusiness() {  LobId = 1 , LobName ="Auto" , SimplifiedInterface = true },
                new LineofBusiness() {  LobId = 1 , LobName ="Bank Loans" , SimplifiedInterface = true },
                new LineofBusiness() {  LobId = 1 , LobName ="Canada Card" , SimplifiedInterface = true },
                new LineofBusiness() {  LobId = 1 , LobName ="UK Card" , SimplifiedInterface = true }
            };
        }
    }
}