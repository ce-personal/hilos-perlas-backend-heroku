namespace Nothing.Models.Api.Product
{
    public class ProductGet
    {
        public Models.Shop.Product? Product { get; set; }
        public List<Models.Shared.File>? Files { get; set; }
    }
}
