namespace Contracts.Domain
{
    public partial class OrderDetailsAudit
    {
        public string OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public string Size { get; set; }
        public double? Price { get; set; }

        public virtual OrdersAudit Order { get; set; }
        public virtual ProductMaster Product { get; set; }
    }
}
