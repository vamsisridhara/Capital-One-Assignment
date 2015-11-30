using AutoMapper;
using GFFIAdmin.Models;
using GFFIAdmin.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace GFFIAdmin.Controllers
{
    public class GenericRepoController : ApiController
    {
        
        private readonly ICustomerAutofacRepository _customerRepository;
        private readonly IGenericRepository<Employee> _empRepository;

        public GenericRepoController()
        {

        }

        public GenericRepoController(ICustomerAutofacRepository customerRepository , 
                                    IGenericRepository<Employee> empRepository)
        {
            this._empRepository = empRepository;
            this._customerRepository = customerRepository;
        }

        // GET: api/Employees
        public List<Employee> GetEmployees()
        {
            return this._empRepository.SelectAll();
        }

        // GET: api/Employees/5
        [ResponseType(typeof(CustomerAutofac))]
        public IHttpActionResult GetEmployee(string id)
        {
            CustomerAutofac list = this._customerRepository.GetCustomerDetails().Where(X => X.CustomerId == id).FirstOrDefault<CustomerAutofac>();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }
    }
}
