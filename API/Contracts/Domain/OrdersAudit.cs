using System;

namespace Contracts.Domain
{
    public partial class OrdersAudit
    {
        public string Id { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
