using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LNDLWcfService.CodeFirstEntities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LNDLWcfService.CodeFirstDAL
{
    public class InventoryRepository
    {
        public List<Inventory> GetInventory()
        {
            InventoryContext inventoryContext = new InventoryContext();

            List<Inventory> li = inventoryContext.Inventory
                //.Include("OrderProduct")
                .ToList();

            foreach (var d in li)
            {
                Console.WriteLine(" ID = " + li.FirstOrDefault(x => x.Id == d.Id).Id
                    //+ " productId = " + li.FirstOrDefault(x => x.productId == d.productId).productId
                    //+ " productDetailId = " + li.FirstOrDefault(x => x.productDetailId == d.productDetailId).productDetailId
                    );
            }
            Console.WriteLine("About to return from InventoryRepsitory class...");
            return li;
        }

        public void insertInventory(Inventory i)
        {
            InventoryContext inventoryContext = new InventoryContext();

            inventoryContext.Inventory.Add(i);
            inventoryContext.SaveChanges();
        }

        public void updateInventory(Inventory i)
        {
            InventoryContext inventoryContext = new InventoryContext();

            //db.Entry(course).State = EntityState.Modified;
            //db.SaveChanges();
            inventoryContext.Entry(i).State = System.Data.Entity.EntityState.Modified;
            inventoryContext.SaveChanges();
        }

    }
}