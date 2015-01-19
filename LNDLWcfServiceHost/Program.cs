using System;
using System.ServiceModel;
using System.Configuration;
using System.Messaging;
using System.Data.Entity;
using LNDLWcfService.CodeFirstDAL;
using LNDLWcfService.CodeFirstEntities;
using System.Collections.Generic;

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
                //CompanyContext cc = new CompanyContext();

                //using (var cc = new CompanyContext())
                //{
                //    Console.WriteLine(cc.Database.Connection.ConnectionString);
                //    if (!cc.Database.Exists())
                //    {
                //        MySeed(cc);
                //        Console.WriteLine("records added...");
                //    }

                //}

                //Console.ReadLine();

                //using (ServiceHost host1 = new ServiceHost(typeof(LNDLWcfService.HywinWcfServices.ProductService.ProductWcfService)))
                //{
                //    host1.Open();
                //    Console.WriteLine("ProductWcfService Host started @ " + DateTime.Now.ToString());

                //    //using (ServiceHost host2 = new ServiceHost(typeof(LNDLWcfService.HywinWcfServices.OrderFromCustomerService.OrderFromCustomerWcfService)))
                //    //{
                //    //    host2.Open();
                //    //    Console.WriteLine("OrderFromCustomerWcfService Host started @ " + DateTime.Now.ToString());

                //    //}
                //}
                Console.ReadLine();
                //Database.SetInitializer<CompanyContext>(new CompanyInitializer());
                //Console.ReadLine();

                //using (ServiceHost MSMQHost = new ServiceHost(typeof(MSMQNonSecurityService.MSMQService)))
                //{
                //    //string queueName = ConfigurationManager.AppSettings["queueName"];
                //    //Console.WriteLine("queueName=" + queueName);

                //    //if (!MessageQueue.Exists(queueName))
                //    //    MessageQueue.Create(queueName, true);
                //    //Console.WriteLine("MessageQueue Created");

                //    ////Receive message, should be used by Admin
                //    //MessageQueue Queue = new MessageQueue(queueName);



                //    MSMQHost.Open();
                //    Console.WriteLine("MSMQService Host started @ " + DateTime.Now.ToString());
                //    Console.ReadLine();

                    //using (ServiceHost productHost = new ServiceHost(typeof(WcfProductService.ProductService)))
                    //{
                    //    productHost.Open();
                    //    Console.WriteLine("ProductService Host started @ " + DateTime.Now.ToString());
                    //    Console.ReadLine();
                    //}
                //}
            }

        }

        //protected static void MySeed(CompanyContext context)
        //{
            //Console.WriteLine("Calling MySeed...");

            //var addresses = new List<Address>
            //{
            //    new Address{Number="41",Street="Aileen Road1",City="Thornhill",State="ON",Country="Canada",ZipCode="L3T 5P7"},
            //    new Address{Number="42",Street="Aileen Road2",City="Thornhill",State="ON",Country="Canada",ZipCode="L3T 5P7"},
            //    new Address{Number="43",Street="Aileen Road3",City="Thornhill",State="ON",Country="Canada",ZipCode="L3T 5P7"},
            //};

            ////addresses.ForEach(s => context.Addresses.Add(s));
            ////context.SaveChanges();

            //var companies = new List<Company>
            //{
            //    new Company{BriefName="HW",FullName="Hywin HiTech Ltd.",companyType=(CompanyType)0,Phone="416-888-6666",Email="hpqiang@gmail.com", WebSite="localhost",DateSince=DateTime.Parse("2014-10-11"),IsActive=true},
            //    new Company{BriefName="YH",FullName="YongHe Textile Ltd.",companyType=(CompanyType)1,Phone="86057233338888",Email="info@yh.com", WebSite="localhost",DateSince=DateTime.Parse("2014-10-11"),IsActive=true},
            //    new Company{BriefName="QC",FullName="QuiltCraft Curtain & Bedding Ltd.",companyType=(CompanyType)2,Phone="503-917-3333",Email="admin@quiltcraft.com", DateSince=DateTime.Parse("2014-10-11"),WebSite="localhost",IsActive=true}
            //};
            ////DateSince=DateTime.Parse("2014-10-11"),

            //companies.ForEach(s => context.Companies.Add(s));
            //context.SaveChanges(); var persons = new List<Person>
            //{
            //    new Person{FirstName="Mike",LastName="Qiang",ManagerId=0,MobilePhone="416-845-1823",Email="hpqiang@hotmail.com",photo="MQ"},
            //    new Person{FirstName="Wenli",LastName="Wang",ManagerId=1,MobilePhone="418-845-1823",Email="wlwang18@hotmail.com",photo="WL"},
            //    new Person{FirstName="Hua",LastName="Zhang",ManagerId=0,MobilePhone="138197190453",Email="hz@163.com",photo=null},
            //    new Person{FirstName="JingSheng",LastName="Wang",ManagerId=3,MobilePhone="1391971333353",Email="jswang@163.com",photo=null},
            //    new Person{FirstName="John",LastName="Smith",ManagerId=0,MobilePhone="978-222-3234",Email="jsmith@quiltcraft.com",photo=null}
            //};

            //persons.ForEach(s => context.Contacts.Add(s));
            //context.SaveChanges();

        //}

    }
}
