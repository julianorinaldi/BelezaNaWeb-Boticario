namespace BelezaNaWebDomain
{
    public class Product
    {
        public string SKU { get; set; }
        public string Name { get; set; }

        public Inventory Inventory { get; set; }

        public string InventoryId { get; set; }

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