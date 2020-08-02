using System.Collections.Generic;

namespace Domain
{
    public partial class CategoryMaster
    {
        public CategoryMaster()
        {
            ProductMaster = new HashSet<ProductMaster>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductMaster> ProductMaster { get; set; }
    }
}
