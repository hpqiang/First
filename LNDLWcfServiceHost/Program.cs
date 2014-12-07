using System;
using System.ServiceModel;
using System.Configuration;
using System.Messaging;

//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace LNDLWcfServiceHost
{
    public class Program
    {
        public static void Main(String[] args)  //Have to be 'Main', not 'main'
        {
            using (ServiceHost host = new ServiceHost(typeof(LNDLWcfService.LNDLWcfService)))
            {
                host.Open();
                Console.WriteLine("LNDLWcfService Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();

                using (ServiceHost MSMQHost = new ServiceHost(typeof(MSMQNonSecurityService.MSMQService)))
                {
                    //string queueName = ConfigurationManager.AppSettings["queueName"];
                    //Console.WriteLine("queueName=" + queueName);

                    //if (!MessageQueue.Exists(queueName))
                    //    MessageQueue.Create(queueName, true);
                    //Console.WriteLine("MessageQueue Created");

                    ////Receive message, should be used by Admin
                    //MessageQueue Queue = new MessageQueue(queueName);



                    MSMQHost.Open();
                    Console.WriteLine("MSMQService Host started @ " + DateTime.Now.ToString());
                    Console.ReadLine();

                    using (ServiceHost productHost = new ServiceHost(typeof(WcfProductService.ProductService)))
                    {
                        productHost.Open();
                        Console.WriteLine("ProductService Host started @ " + DateTime.Now.ToString());
                        Console.ReadLine();
                    }
                }
            }

        }
    }
}
