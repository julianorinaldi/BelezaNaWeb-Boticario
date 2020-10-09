using BelezaNaWebDomain.Entities;

namespace BelezaNaWebDomain
{
    public class Product : EntityBase
    {
        public long? SKU { get; set; }
        public string Name { get; set; }

        public virtual Inventory Inventory { get; set; }

        public bool IsMarketable
        {
            get
            {
                if (Inventory?.Quantity > 0)
                    return true;

                return false;
            }
        }
    }
}