namespace Domain
{
    public partial class AllergenMaster
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public bool? IsVegan { get; set; }
        public bool? IsGlutenfree { get; set; }
        public bool? IsLactoseIntolerant { get; set; }
        public bool? IsSulphiteFree { get; set; }

        public virtual ProductMaster Product { get; set; }
    }
}
