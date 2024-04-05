
namespace usingMinimalAPI.Services
{
    public interface IProductService
    {
        int CreateNewProduct(CreateProductRequest request);
        ProductItemResponse? GetProduct(int id);
        IEnumerable<ProductItemResponse> GetProducts();
        IEnumerable<ProductItemResponse> Search(string name);
    }
}