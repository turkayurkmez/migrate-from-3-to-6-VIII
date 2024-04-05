using WhatsNewInASPNETSix.Models;

namespace WhatsNewInASPNETSix.Services
{
    public class AlternateProductService : IProductService
    {
        public List<ProductDto> GetProducts()
        {
            return new()
            {
                new(1,"Ürün A",500),
                new(2,"Ürün B",250),

            };

        }
    }
}
