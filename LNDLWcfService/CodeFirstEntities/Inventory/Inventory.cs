using LNDLWcfService.CodeFirstEntities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    public enum Unit
    {
        BOX=1,
        ROLL
    };

    //public class PositionAndAmount
    //{
    //    public int Id { get; set; }

    //    public string rack { get; set; }
    //    public string layer { get; set; }
    //    public int amount { get; set; }
    //}

    //public class InList
    //{
    //    public int Id { get; set; }

    //    public DateTime? inTime { get; set; }
    //    public int amount { get; set; }
    //}

    //public class OutList
    //{
    //    public int Id { get; set; }

    //    public DateTime? outTime { get; set; }
    //    public int amount { get; set; }
    //}

    public class Inventory
    {
        public int Id { get; set; }

        //public int productId { get; set; }
        //public int productDetailId { get; set; }
        //public string rack { get; set; }
        //public string layer { get; set; }
        //public int amount { get; set; }
        //public DateTime? inTime { get; set; }
        //public DateTime? outTime { get; set; }
        //public int amountPerUnit { get; set; }
        //public Unit unit { get; set; }
        
        public int threshhold { get; set; }

        public virtual List<Shipping> InComingList { get; set; }
        public virtual List<Sale> SaleOutList { get; set; }
        //public List<PositionAndAmount> positionAndAmount { get;set;}
        //public List<InList> inList { get; set; }
        //public List<OutList> outList { get; set; }
        //public List<PositionAndAmount> PositionAndAmounts { get; set; }

    }
}