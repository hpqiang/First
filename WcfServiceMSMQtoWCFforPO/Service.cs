using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Web;

namespace WcfServiceMSMQtoWCFforPO
{
    // Define the Purchase Order Line Item
    [Serializable]
    public class PurchaseOrderLineItem
    {

        public string productId;
        public float unitCost;
        public int quantity;

        public override string ToString()
        {
            String displayString = "Order LineItem: " + quantity + " of " + productId + " @unit price: $" + unitCost + "\n";
            return displayString;
        }

        public float TotalCost
        {
            get { return unitCost * quantity; }
        }
    }

    public enum OrderStates
    {
        Pending,
        Processed,
        Shipped
    }

    // Define Purchase Order
    [Serializable]
    public class PurchaseOrder
    {
        public static string[] OrderStates = { "Pending", "Processed", "Shipped" };
        public string poNumber;
        public string customerId;
        public PurchaseOrderLineItem[] orderLineItems;
        public OrderStates orderStatus;

        public float TotalCost
        {
            get
            {
                float totalCost = 0;
                foreach (PurchaseOrderLineItem lineItem in orderLineItems)
                    totalCost += lineItem.TotalCost;
                return totalCost;
            }
        }

        public OrderStates Status
        {
            get
            {
                return orderStatus;
            }
            set
            {
                orderStatus = value;
            }
        }

        public override string ToString()
        {
            StringBuilder strbuf = new StringBuilder("Purchase Order: " + poNumber + "\n");
            strbuf.Append("\tCustomer: " + customerId + "\n");
            strbuf.Append("\tOrderDetails\n");

            foreach (PurchaseOrderLineItem lineItem in orderLineItems)
            {
                strbuf.Append("\t\t" + lineItem.ToString());
            }

            strbuf.Append("\tTotal cost of this order: $" + TotalCost + "\n");
            strbuf.Append("\tOrder status: " + Status + "\n");
            return strbuf.ToString();
        }
    }

    // Define a service contract. 
    [ServiceContract]//(Namespace = "http://Microsoft.Samples.MSMQToWCF")]
    [ServiceKnownType(typeof(PurchaseOrder))]
    public interface IOrderProcessor
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> msg);
    }

    // Service class which implements the service contract.
    // Added code to write output to the console window
    public class OrderProcessorService : IOrderProcessor
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> ordermsg)
        {
            PurchaseOrder po = ordermsg.Body;
            Random statusIndexer = new Random();
            po.Status = (OrderStates)statusIndexer.Next(3);
            Console.WriteLine("Processing {0} ", po);
        }

        // Host the service within this EXE console application.
        public static void Main()
        {
            // Get MSMQ queue name from app settings in configuration
            string queueName = ConfigurationManager.AppSettings["orderQueueName"];
            Console.WriteLine("queueName {0}", queueName);

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            // Create a ServiceHost for the OrderProcessorService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(OrderProcessorService)))
            {
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();
            }
        }
    }
}