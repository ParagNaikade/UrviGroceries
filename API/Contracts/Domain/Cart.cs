using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Domain
{
    public partial class Cart
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Users EmailNavigation { get; set; }
        public virtual ProductMaster Product { get; set; }
    }
}
