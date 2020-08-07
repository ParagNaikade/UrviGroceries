using System.Collections.Generic;

namespace Contracts.Domain
{
    public partial class ProductMaster
    {
        public ProductMaster()
        {
            AllergenMaster = new HashSet<AllergenMaster>();
            ImageMaster = new HashSet<ImageMaster>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public int BrandId { get; set; }

        public virtual BrandMaster Brand { get; set; }
        public virtual CategoryMaster Category { get; set; }
        public virtual ICollection<AllergenMaster> AllergenMaster { get; set; }
        public virtual ICollection<ImageMaster> ImageMaster { get; set; }
    }
}
