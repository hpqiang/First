using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.ServiceModel.Web;
using System.Text;

namespace MSMQNonSecurityService
{
    [ServiceContract]
    //[ServiceKnownType(typeof(PurchaseOrder))]
    //[ServiceContract(SessionMode = SessionMode.Required)]
    public interface IMSMQService
    {

        [OperationContract(IsOneWay=true)]
        void ShowMessage(string msg);

        //[OperationContract(IsOneWay = true)]
        //void AddMessage(MyMsg msg);
        //[OperationContract(IsOneWay = true)]
        //void GetMessage();
        //[OperationContract(IsOneWay = true)]
        //void RemoveMessage(MyMsg msg);
        //[OperationContract(IsOneWay = true)]
        //void printMessage();


        //[OperationContract(IsOneWay = true)]
        //void OpenPurchaseOrder(string customerId);
        //[OperationContract(IsOneWay = true)]
        //void AddProductLineItem(string productId, int quantity);
        //[OperationContract(IsOneWay = true)]
        //void EndPurchaseOrder();

        //[OperationContract(IsOneWay = true)]
        //void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> msg);


    }



    //[DataContract]
    //public class MyMsg
    //{
    //    [DataMember]
    //    public string from;
    //    [DataMember]
    //    public string to;
    //    [DataMember]
    //    public string msg;
    //}

    //[DataContract]
    //public class PurchaseOrderLineItem
    //{
    //    [DataMember]
    //    public string ProductId;

    //    [DataMember]
    //    public float UnitCost;

    //    [DataMember]
    //    public int Quantity;

    //    public override string ToString()
    //    {
    //        String displayString = "Order LineItem: " + Quantity + " of " + ProductId + " @unit price: $" + UnitCost + "\n";
    //        return displayString;
    //    }

    //    public float TotalCost
    //    {
    //        get { return UnitCost * Quantity; }
    //    }
    //}

    //public enum OrderStates
    //{
    //    Pending,
    //    Processed,
    //    Shipped
    //}

    //[DataContract]
    //public class PurchaseOrder
    //{
    //    //static readonly string[] OrderStates = { "Pending", "Processed", "Shipped" };
    //    public OrderStates orderStatus;
    //    static Random statusIndexer = new Random(137);

    //    [DataMember]
    //    public string PONumber;

    //    [DataMember]
    //    public string customerId;

    //    [DataMember]
    //    public PurchaseOrderLineItem[] orderLineItems;

    //    public float TotalCost
    //    {
    //        get
    //        {
    //            float totalCost = 0;
    //            foreach (PurchaseOrderLineItem lineItem in orderLineItems)
    //            {
    //                totalCost += lineItem.TotalCost;
    //            }
    //            return totalCost;
    //        }
    //    }

    //    //public string Status
    //    //{
    //    //    get
    //    //    {
    //    //        return OrderStates[statusIndexer.Next(3)];
    //    //    }
    //    //}

    //    public override string ToString()
    //    {
    //        System.Text.StringBuilder strbuf = new System.Text.StringBuilder("Purchase Order: " + PONumber + "\n");
    //        strbuf.Append("\tCustomer: " + customerId + "\n");
    //        strbuf.Append("\tOrderDetails\n");

    //        foreach (PurchaseOrderLineItem lineItem in orderLineItems)
    //        {
    //            strbuf.Append("\t\t" + lineItem.ToString());
    //        }

    //        strbuf.Append("\tTotal cost of this order: $" + TotalCost + "\n");
    //        //strbuf.Append("\tOrder status: " + Status + "\n");
    //        return strbuf.ToString();
    //    }

    //}

    //// Order Processing Logic
    //// Can replace with transaction-aware resource such as SQL or transacted hashtable to hold the purchase orders.
    //// This example uses a non-transactional resource.
    //public class Orders
    //{
    //    static Dictionary<string, PurchaseOrder> purchaseOrders = new Dictionary<string, PurchaseOrder>();

    //    public static void Add(PurchaseOrder po)
    //    {
    //        purchaseOrders.Add(po.PONumber, po);
    //    }

    //    //public static string GetOrderStatus(string PONumber)
    //    //{
    //    //    PurchaseOrder po;
    //    //    if (purchaseOrders.TryGetValue(PONumber, out po))
    //    //    {
    //    //        return po.Status;
    //    //    }
    //    //    else
    //    //        return null;
    //    //}

    //    public static void DeleteOrder(string PONumber)
    //    {
    //        if (purchaseOrders[PONumber] != null)
    //        {
    //            purchaseOrders.Remove(PONumber);
    //        }
    //    }
    //}
}
