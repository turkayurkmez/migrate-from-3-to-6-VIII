using WhatsNewInASPNETSix.Models;

namespace WhatsNewInASPNETSix.Services
{
    public interface IProductService
    {
        List<ProductDto> GetProducts();
    }
}