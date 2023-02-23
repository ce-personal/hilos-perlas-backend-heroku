using Nothing.Models.Shared;
using Nothing.Models.Shop;

namespace Nothing.Models.Api.Order
{
    public class ItemOrderProductGet
    {
        public Models.Shop.Product Product { get; set; }
        public List<Models.Shared.File> Files { get; set; }
        public int Quantity { get; set; }
    }
}
