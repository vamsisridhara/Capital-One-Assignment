using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDI.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetByID(int id);
        void Add(Product product);
    }
}
