using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GFFIAdmin.Models
{
    public class CustomerAutofac
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
    }
    /// <summary>
    /// ICustomerRepository interface
    /// </summary>
    public interface ICustomerAutofacRepository
    {
        List<CustomerAutofac> GetCustomerDetails();
    }
    /// <summary>
    /// Customer details repository class
    /// </summary>
    public class CustomerAutofacRepository : ICustomerAutofacRepository
    {
        /// <summary>
        /// Get customer details.
        /// </summary>
        /// <returns></returns>
        public List<CustomerAutofac> GetCustomerDetails()
        {
            // This is a simple implementation, others could use an ORM or Web service etc.

            var customers = new List<CustomerAutofac>
                          {
                              new CustomerAutofac()
                                  {
                                      CustomerId = "1",
                                      CustomerName = "Customer one",
                                      CustomerAddress = "Bristol",
                                      CustomerPhoneNumber = "0845000000",
                                      CustomerEmail = "x@y.com",
                                  },
                              new CustomerAutofac()
                                  {
                                      CustomerId = "2",
                                      CustomerName = "Customer two",
                                      CustomerAddress = "Bath",
                                      CustomerPhoneNumber = "0845000001",
                                      CustomerEmail = "x@x.com",
                                  },
                              new CustomerAutofac()
                                  {
                                      CustomerId = "3",
                                      CustomerName = "Customer three",
                                      CustomerAddress = "Swindon",
                                      CustomerPhoneNumber = "0845000003",
                                      CustomerEmail = "y@y.com",
                                  }
                          };

            return customers;
        }
    }
}