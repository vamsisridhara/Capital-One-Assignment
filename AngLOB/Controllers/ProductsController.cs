using AngLOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AngLOB.Controllers
{
    public class ProductsController : ApiController
    {
        public static List<Product> listProducts = new List<Product>() {
            new Product()
            {
                productID = 1,
                productName = "TEST1" ,
                productCode = "P1" ,
                productDate = "March 24 1980" ,
                price = 20.9M,
                cost = 22.0M,
                description = "test",
                marginPercent = 20,
                releaseDate = "March 24 1980",
                tagList = new List<String>() {"test","test2"},
                imageURL = ""
            },
            new Product()
            {
                productID = 2,
                productName = "TEST2" ,
                productCode = "P1" ,
                productDate = "March 24 1980" ,
                price = 20.9M,
                cost = 22.0M,
                description = "test",
                marginPercent = 20,
                releaseDate = "March 24 1980",
                tagList = new List<String>() {"test","test2"},
                imageURL = ""
            },
            new Product()
            {
                productID = 3,
                productName = "TEST3" ,
                productCode = "P1" ,
                productDate = "March 24 1980" ,
                price = 20.9M,
                cost = 22.0M,
                description = "test",
                marginPercent = 20,
                releaseDate = "March 24 1980",
                tagList = new List<String>() {"test","test2"},
                imageURL = ""
            },
            new Product()
            {
                productID = 4,
                productName = "TEST4" ,
                productCode = "P1" ,
                productDate = "March 24 1980" ,
                price = 20.9M,
                cost = 22.0M,
                description = "test",
                marginPercent = 20,
                releaseDate = "March 24 1980",
                tagList = new List<String>() {"test","test2"},
                imageURL = ""
            }
        };

        [HttpGet]
        [Route("api/products")]
        public List<Product> getproducts()
        {
            return listProducts;
        }

        [HttpGet]
        [Route("api/products/{productID}")]
        public Product getproducts(int productID)
        {
            return listProducts.Where(x => x.productID == productID).Select(x => x).FirstOrDefault();
        }

        [HttpPost]
        [Route("api/products")]
        public List<Product> postproducts([FromBody]Product product)
        {
            listProducts.Add(product);
            return listProducts;
        }
        

    }
}