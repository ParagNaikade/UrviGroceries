using System.Collections.Generic;

namespace Contracts.Domain
{
    public class BrandMaster
    {
        public BrandMaster()
        {
            ProductMaster = new HashSet<ProductMaster>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductMaster> ProductMaster { get; set; }
    }
}
