using GFFIAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GFFIAdmin.Controllers
{
    public class AutofacTestController : Controller
    {
        /// <summary>
        /// Private _container field
        /// </summary>
        private readonly ICustomerAutofacRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="customerRepository">The customer repository.</param>
        public AutofacTestController(ICustomerAutofacRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: /Customer/

        /// <summary>
        /// Method for index action.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //@model AutofacDemo.Customer
            var customer = _customerRepository.GetCustomerDetails();

            // View Index.cshtml
            return View(customer);
        }
    }
}