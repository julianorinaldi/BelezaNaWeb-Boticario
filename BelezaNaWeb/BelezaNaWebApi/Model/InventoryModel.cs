using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWebApi.Model
{
    public class InventoryModel
    {
        public long Quantity
        {
            get
            {
                if (Warehouses?.Count > 0)
                    return Warehouses.Sum(x => x.Quantity);

                return 0;
            }
        }

        public virtual List<WarehouseModel> Warehouses { get; set; }
    }
}