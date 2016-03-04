using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GFFIAdmin.Controllers
{
    public class SelectListItems
    {
        public IEnumerable<SelectListItem> userlist { get; set; }
        public IEnumerable<SelectListItem> retailerlist { get; set; }
        public IEnumerable<SelectListItem> supplierlist { get; set; }
    }

    public class UserRelationController : Controller
    {
        // GET: UserRelation
        public ActionResult Index()
        {
            SelectListItems items = new SelectListItems()
            {
                userlist = new List<SelectListItem>()
                {
                    new SelectListItem() {  Text = "Admin", Value="1", Selected = false},
                    new SelectListItem() {  Text = "User", Value="2", Selected = false},
                },
                retailerlist = new List<SelectListItem>()
                {
                    new SelectListItem() {  Text = "Retailer1", Value="1", Selected = false},
                    new SelectListItem() {  Text = "Retailer2", Value="2", Selected = false},
                }
            };
            return View(items);
        }
    }
}