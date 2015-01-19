using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    public enum OrderStatus
    {
        RECEIVED = 1,
        ISSUES,
        MANU, //Manufactering
        SHIP,
        ARRIVE
    }
    //public enum PaymentStatus
    //{
    //    DEPOSIT = 1,
    //    INVOICED,
    //    PAID
    //}

    //[ComplexType]
    //public class TimeCollection
    //{
    //    public DateTime? issueDate;
    //    public DateTime? expectedDatebyCustomer;
    //    public DateTime? expectedDate;
    //    public DateTime? manufacturingDate;
    //    public DateTime? exMillDate;
    //    public DateTime? shippingDate;
    //    public DateTime? arriveDate;
    //    public DateTime? inWareHouseDate;
    //}

    public enum MoneyType
    {
        USD=1,
        RMB,
        CAD
    }

    public class Paying
    {
        public double amount;
        public MoneyType type;
    }

    public class OrderToOrder
    {
        public int Id { get; set; }

        //[ForeignKey("OrderFromCustomer")]
        //public int orderFromCustomerId { get; set; }
        //[ForeignKey("OrderToSupplier")]
        //public int orderToSupplierId { get; set; }

        //public OrderFromCustomer OrderFromCustomer { get; set; }
        //public OrderToSupplier OrderToSupplier { get; set; }

        public OrderStatus? orderStatus { get; set; }
        //public TimeCollection inProcess { get; set; }

        public DateTime? issueDate { get; set; }
        public DateTime? expectedDatebyCustomer { get; set; }
        public DateTime? expectedDate { get; set; }
        public DateTime? manufacturingDate { get; set; }
        public DateTime? exMillDate { get; set; }
        public DateTime? shippingDate { get; set; }
        public DateTime? arriveDate { get; set; }
        public DateTime? inWareHouseDate { get; set; }

        //public PaymentStatus? paymentStatus { get; set; }
        //public Paying amountPaidByCustomer { get; set; }
        //public Paying amountOwingByCustomer { get; set; }
        //public Paying amountPaidToSupplier { get; set; }
        //public Paying amountOwingToSupplier { get; set; }
        //public Paying amountPaidToShipper { get; set; }
        //public Paying amountOwingToShipper { get; set; }
        //public Paying amountPaidToOther{ get; set; }
        //public Paying amountOwingToOther { get; set; }

        //public double amountPaidByCustomer { get; set; }
        //public double amountOwingByCustomer { get; set; }
        //public double amountPaidToSupplier { get; set; }
        //public double amountOwingToSupplier { get; set; }
        //public double amountPaidToShipper { get; set; }
        //public double amountOwingToShipper { get; set; }
        //public double amountPaidToOther { get; set; }
        //public double amountOwingToOther { get; set; }
        //public MoneyType moneyType { get; set; }


        //public string amountPaidOther { get; set; }
    }
}