using System;
using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWebDomain
{
    public class Inventory
    {
        private string Id { get; set; }

        public Inventory()
        {
            Id = Guid.NewGuid().ToString();
        }

        public long Quantity
        {
            get
            {
                if (Warehouses?.Length > 0)
                    return Warehouses.Sum(x => x.Quantity);

                return 0;
            }
        }

        public Product Product { get; set; }

        public string ProductId { get; set; }

        public Warehouse[] Warehouses { get; set; }
    }
}