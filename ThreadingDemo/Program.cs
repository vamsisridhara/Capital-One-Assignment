using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingDemo
{
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

    public static class GenericMap<T,D>
    {
        public static List<D> MaptoDTO(T source, D destination , DbContext dbcontext, IQueryable<T> order)
        {
            Mapper.CreateMap<T, D>();
            var dbcontext = new NorthwindEntities();
            var ordervmlist = new List<D>();
            if (order.Any())
            {
                ordervmlist = Mapper.Map<List<T>, List<D>>(order.ToList());
            }

        }
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

        static void Main(string[] args)
        {
            //Autofacinitialize();
            //ThreadingInvoke();
            automapinitialize();
            Console.Read();
            
        }

        private static void automapinitialize()
        {
            Mapper.CreateMap<Order,OrdersVM>();
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
