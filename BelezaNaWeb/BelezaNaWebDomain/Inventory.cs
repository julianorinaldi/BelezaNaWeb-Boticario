using BelezaNaWebDomain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWebDomain
{
    public class Inventory : EntityBase
    {
        public Inventory()
        {
        }

        public long Quantity
        {
            get
            {
                if (Warehouses?.Count > 0)
                    return Warehouses.Sum(x => x.Quantity);

                return 0;
            }
        }

        public virtual Product Product { get; set; }

        public string ProductId { get; set; }

        public virtual List<Warehouse> Warehouses { get; set; }
    }
}