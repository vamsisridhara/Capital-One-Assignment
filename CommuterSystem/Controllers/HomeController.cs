using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommuterSystem.Controllers
{
    public class HomeController : Controller
    {
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
