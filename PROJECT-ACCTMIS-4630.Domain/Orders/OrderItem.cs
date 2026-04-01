using PROJECT_ACCTMIS_4630.Domain.Catalog;

namespace PROJECT_ACCTMIS_4630.Domain.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price => Item.Price * Quantity;
    }
}
