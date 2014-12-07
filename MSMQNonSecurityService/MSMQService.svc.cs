using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.ServiceModel.Web;
using System.Text;

namespace MSMQNonSecurityService
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    public class MSMQService : IMSMQService
    {
        //private List<MyMsg> listMsg = new List<MyMsg>();

        public void ShowMessage(string msg)
        {
            Console.WriteLine(msg + " Received at: "+System.DateTime.Now.ToString());
        }

        //public void AddMessage(MyMsg msg)
        //{
        //    listMsg.Add(msg);
        //    printMessage();
        //}

        //public void GetMessage()
        //{
        //    List<MyMsg> l = new List<MyMsg>();

        //    foreach (MyMsg m in listMsg)
        //    {
        //        l.Add(m);
        //    }

        //    return;
        //}

        //public void RemoveMessage(MyMsg msg)
        //{
        //    bool b = listMsg.Remove(msg);
        //    return;
        //}

        //public void printMessage()
        //{
        //    foreach (MyMsg m in listMsg)
        //    {
        //        Console.WriteLine("from: " + m.from + "with message: " + m.msg + "to: " + m.to);
        //    }
        //}


        //[OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        //public void SubmitPurchaseOrder(PurchaseOrder po)
        //{
        //    Console.WriteLine("Submitting PO {0}", po);
        //    Orders.Add(po);
        //}

        //[OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        //public void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> ordermsg)
        //{
        //    PurchaseOrder po = ordermsg.Body;
        //    Random statusIndex = new Random();
        //    po.orderStatus = (OrderStates)statusIndex.Next(3);
        //    Console.WriteLine("Submitting PO {0}", po);
        }
        //PurchaseOrder po;

        //[OperationBehavior(TransactionScopeRequired=true, TransactionAutoComplete=false)]
        //public void OpenPurchaseOrder(string customerId)
        //{
        //    Console.WriteLine("Creating PO");
        //    po = new PurchaseOrder(customerId);
        //}

        //[OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        //public void AddProductLineItem(string productId, int quantity)
        //{
            
        //}

    //}

    //public class PurchaseOrder
    //{
    //    string customerId;
    //    string purchaseOrderId;

    //    public PurchaseOrder(string customerId)
    //    {
    //        this.customerId = customerId;
    //    }


    //}
}
