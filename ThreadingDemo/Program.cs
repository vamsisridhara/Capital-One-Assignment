using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;

namespace ThreadingDemo
{
    public class Student
    {
        public Student()
        {

        }
        public int studentid { get; set; }
        public string studentname { get; set; }
        public string address { get; set; }
    }
    public class Product
    {
        public String Name { get; set; }
        public Int32 ProductId { get; set; }
        public Decimal Cost { get; set; }
        public Int32 Quantity { get; set; }
    }
    public class OrdersVM
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
    }

    //public static class GenericMap<T,D>
    //{
    //    public static List<D> MaptoDTO(T source, D destination , DbContext dbcontext, IQueryable<T> order)
    //    {
    //        Mapper.CreateMap<T, D>();
    //        var dbcontext = new NorthwindEntities();
    //        var ordervmlist = new List<D>();
    //        if (order.Any())
    //        {
    //            ordervmlist = Mapper.Map<List<T>, List<D>>(order.ToList());
    //        }

    //    }
    //}
    public class Invoice
    {
        public DateTime InvoiceDate { get; set; }
        public int InvoiceType { get; set; }
        public decimal InvoiceAmount { get; set; }
        public int NumberOfItems { get; set; }
    }
    class Program
    {
        public static void WriteDate()
        {
            // Create the scope, resolve your IDateWriter,
            // use it, then dispose of the scope.
            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }
        }

        private static IContainer Container { get; set; }

        private static List<Invoice> getinvoices()
        {
            List<Invoice> invoiceList = new List<Invoice>
            {
              new Invoice()
              {
                InvoiceDate=new DateTime(2010,4,30),
                InvoiceType = 1,
                InvoiceAmount = 150,
                NumberOfItems = 8
              },
              new Invoice()
              {
                InvoiceDate=new DateTime(2010,4,29),
                InvoiceType = 2,
                InvoiceAmount = 215,
                NumberOfItems = 7
              },
              new Invoice()
              {
                InvoiceDate=new DateTime(2010,4,30),
                InvoiceType = 1,
                InvoiceAmount = 50,
                NumberOfItems = 2
              },
              new Invoice()
              {
                InvoiceDate=new DateTime(2010,4,29),
                InvoiceType = 2,
                InvoiceAmount = 550,
                NumberOfItems = 5
              }
            };
            return invoiceList;
        }

        static void Main(string[] args)
        {
            IList liststud = new ArrayList();
            for (int count = 0; count < 100; count++)
            {
                liststud.Add(new Student() { studentid = count, address = "add" + count, studentname = "st" + count });
            }
            List<Student> lst = new List<Student>();
            foreach (var item in liststud)
            {
                lst.Add((Student)item);
            }




            List<Invoice> list = getinvoices();
            var query = list.GroupBy(g => new
            {
                g.InvoiceDate,
                g.InvoiceType
            })
            .Select(group => new
            {
                InvoiceDate = group.Key.InvoiceDate,
                InvoiceType = group.Key.InvoiceType,
                TotalAmount = group.Sum(a => a.InvoiceAmount),
                TotalCount = group.Sum(c => c.NumberOfItems)
            });

            foreach (var item in query)
            {
                Console.WriteLine("Invoice Date: {0} ({1}) TotalAmount: {2} TotalCount: {3}",
                                    item.InvoiceDate.ToShortDateString(),
                                    item.InvoiceType,
                                    item.TotalAmount,
                                    item.TotalCount);
            }
            //Autofacinitialize();
            //ThreadingInvoke();
            IList<Product> cartlist = new List<Product>()
            {
                new Product() { ProductId =1, Name= "Mens Watches" , Cost = 500.45m , Quantity =1 },
                new Product() { ProductId =2, Name= "Perfumes" , Cost = 500.45m , Quantity =2},
                new Product() { ProductId =3, Name= "Clothes" , Cost = 500.45m , Quantity =3},
                new Product() { ProductId =4, Name= "Ladies Watches" , Cost = 500.45m , Quantity =4 },
            };
            IList<Product> recommendedList = new List<Product>()
            {
                new Product() { ProductId =1, Name= "Mens Watches" , Cost = 500.45m , Quantity =1 },
                new Product() { ProductId =2, Name= "Perfumes" , Cost = 500.45m , Quantity =1 },
                new Product() { ProductId =3, Name= "Clothes" , Cost = 500.45m , Quantity =1 },
                new Product() { ProductId =4, Name= "Ladies Watches" , Cost = 500.45m , Quantity =1 },
                new Product() { ProductId =5, Name= "Laptops" , Cost = 500.45m , Quantity =1 },
                new Product() { ProductId =6, Name= "DSLR Cameras" , Cost = 500.45m , Quantity =1 },
            };

            IList<Product> purchasedProducts = RecommendedProductsPurchased(cartlist: cartlist,
                                                recommendedList: recommendedList);

            //automapinitialize();
            Console.Read();
        }


        //public DataTable SearchProducts()
        //{
        //DataTable dt = null;
        //string cmdText = string.Format("SELECT * FROM Products WHERE ProductName LIKE @prodcutName");
        //try
        //{
        //    using (SqlConnection _connection = new SqlConnection(""))
        //    {
        //        string searchTerm = string.Format("%{0}%", txtSearchBox.Text);
        //        SqlCommand sqlComm = new SqlCommand(cmdText, _connection);
        //        SqlParameter sqlparam = new SqlParameter("@productName", searchTerm);
        //        sqlComm.Parameters.Add(sqlparam);
        //        sqlComm.CommandType = CommandType.Text;
        //        if (_connection.State == ConnectionState.Closed) { _connection.Open(); }
        //        SqlDataAdapter da = new SqlDataAdapter(sqlComm);
        //        dt = new DataTable();
        //        da.Fill(dt);
        //    }

        //}
        //catch (Exception exception)
        //{
        //    //log the error message
        //    throw;
        //}
        //finally
        //{
        //    //we can close the sql connection in finally block or implement a class which takes care
        //    //of sql connection implementing IDisposable interface.
        //}
        //return dt;
        // }

        static IList<Product> RecommendedProductsPurchased(IList<Product> cartlist, IList<Product> recommendedList)
        {
            IList<Product> purchasedList = null;
            if (cartlist != null && cartlist.Count > 0 && recommendedList != null && recommendedList.Count > 0)
            {
                purchasedList = new List<Product>();
                var list = Enumerable.Join(cartlist, recommendedList, cart => cart.ProductId, recomlist => recomlist.ProductId,
                    (cart, recomlist) =>
                {
                    if (cart.ProductId.Equals(recomlist.ProductId))
                    {
                        purchasedList.Add(cart);
                    }
                    return cart.Name;
                }).ToList();
            }
            return purchasedList;
        }
        private static void automapinitialize()
        {
            Mapper.CreateMap<Order, OrdersVM>();
            var context = new NorthwindEntities();
            var orderList = from ord in context.Orders select ord;
            var ordervmlist = new List<OrdersVM>();
            if (orderList.Any())
            {
                ordervmlist = Mapper.Map<List<Order>, List<OrdersVM>>(orderList.ToList());
            }
        }

        private static void ThreadingInvoke()
        {
            MultiThreadTest threadTest = new MultiThreadTest();
            threadTest.proessMultithreading();

            threadTest.ProcessWriteMult();
            Console.Read();
        }

        private static void Autofacinitialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<TodayWriter>().As<IDateWriter>();
            Container = builder.Build();
            WriteDate();
        }
    }
    //create a class 
    public class MultiThreadTest
    {
        //create an object
        public object tLock = new object();

        //method to write 
        public void proessMultithreading()
        {
            //use the lock mechanism
            lock (tLock)
            {
                Console.WriteLine(" {0} is Executing", Thread.CurrentThread.Name);
                for (int count = 0; count < 10; count++)
                {
                    //keep the thread sleep
                    Thread.Sleep(new Random().Next(5));
                    Console.WriteLine(" {0},", count);
                }
                Console.WriteLine();
            }
        }

        public async void ProcessWriteMult()
        {
            //create list of Task
            List<Task> tasksList = new List<Task>();
            //create list of FileStreams
            List<FileStream> sourceStreams = new List<FileStream>();
            try
            {
                for (int index = 1; index <= 10; index++)
                {
                    //assign the file path to store the files
                    string filePath = @"c:\tempfolder\" + "content" + index.ToString("00") + ".txt";
                    //get the byte
                    byte[] encodedText = Encoding.Unicode.GetBytes("In file " + index.ToString() + "\r\n");
                    //assign the file stream
                    FileStream sourceStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None,
                                                      bufferSize: 4096, useAsync: true);
                    //write the content
                    Task theTask = sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
                    //add the source stream to list of source stream
                    sourceStreams.Add(sourceStream);
                    //add the list of tasks 
                    tasksList.Add(theTask);
                }
                //
                await Task.WhenAll(tasksList);
            }
            catch (Exception exception)
            {
                //log the exception
                Console.WriteLine("Exception thrown at : " + exception.InnerException.Message);
            }
            finally
            {
                //close the file streams
                foreach (FileStream sourceStream in sourceStreams)
                {
                    sourceStream.Close();
                }
            }
        }
    }
}
