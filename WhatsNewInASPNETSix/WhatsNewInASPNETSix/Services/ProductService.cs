using WhatsNewInASPNETSix.Models;

namespace WhatsNewInASPNETSix.Services
{
    public class ProductService : IProductService
    {
        public List<ProductDto> GetProducts()
        {
            return new()
            {
                new(1,"Klavye",2500),
                new(1,"Mouse",1500),

            };
        }
    }
}
