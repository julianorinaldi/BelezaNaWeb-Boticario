using System;

namespace BelezaNaWebDomain
{
    public class Warehouse
    {
        private string WarehouseId { get; set; }

        public Warehouse()
        {
            WarehouseId = Guid.NewGuid().ToString();
        }

        public string Locality { get; set; }
        public long Quantity { get; set; }
        public WarehouseType Type { get; set; }
    }
}