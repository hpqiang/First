using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LNDLWcfService.CodeFirstEntities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LNDLWcfService.CodeFirstDAL
{
    public class ShipRepository
    {
        public List<Shipping> GetShipping()
        {
            ShipContext shipContext = new ShipContext();

            List<Shipping> ls = shipContext.Shipping
                //.Include("OrderProduct")
                .ToList();

            foreach (var d in ls)
            {
                Console.WriteLine(" ID = " + ls.FirstOrDefault(x => x.Id == d.Id).Id
                    //+ " productId = " + ls.FirstOrDefault(x => x.productId == d.productId).productId
                    //+ " productDetailId = " + ls.FirstOrDefault(x => x.productDetailId == d.productDetailId).productDetailId
                    );
            }
            Console.WriteLine("About to return from ShipRepsitory class...");
            return ls;
        }

        public void insertShipping(Shipping s)
        {
            ShipContext shipContext = new ShipContext();

            shipContext.Shipping.Add(s);
            shipContext.SaveChanges();
        }

        public void updateShipping(Shipping s)
        {
            ShipContext shipContext = new ShipContext();

            //db.Entry(course).State = EntityState.Modified;
            //db.SaveChanges();
            shipContext.Entry(s).State = System.Data.Entity.EntityState.Modified;
            shipContext.SaveChanges();
        }

    }
}