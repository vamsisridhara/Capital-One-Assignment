using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GFFIAdmin.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private NorthwindEntities db = null;

        public CustomerRepository()
        {
            this.db = new NorthwindEntities();
        }

        public CustomerRepository(NorthwindEntities db)
        {
            this.db = db;
        }

        public IEnumerable<Customer> SelectAll()
        {
            return db.Customers.ToList();
        }

        public Customer SelectByID(string id)
        {
            return db.Customers.Find(id);
        }

        public void Insert(Customer obj)
        {
            db.Customers.Add(obj);
        }

        public void Update(Customer obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            Customer existing = db.Customers.Find(id);
            db.Customers.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}