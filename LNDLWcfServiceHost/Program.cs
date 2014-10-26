using System;
using System.ServiceModel;
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
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
