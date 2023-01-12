namespace Nothing.Models.Shop
{
    public class CustomProduct
    {
        public Guid Id { get; set; }
        public Guid FirstLevelId { get; set; }
        public Guid? SecondLevelId { get; set; }
        public Guid? ThirdLevelId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? ItemOrderId { get; set; }



        public Level? FirstLevel { get; set; }
        public Level? SecondLevel { get; set; }
        public Level? ThirdLevel { get; set; }
        // public Product? Product { get; set; }
        public ItemOrder? ItemOrder { get; set; }
    }
}
