namespace Domain
{
    public partial class ImageMaster
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }

        public virtual ProductMaster Product { get; set; }
    }
}
