namespace usingMinimalAPI.Services
{
    public class ProductService : IProductService
    {

        private List<ProductItemResponse> products = new()
        {
            new(1,"Ürün A",10,"Test"),
            new(2,"Ürün b",15,"Test"),
            new(3,"Ürün c",20,"Test"),
            new(4,"Ürün e",30,"Test"),
            new(5,"Ürün d",50,"Test"),


        };
        public IEnumerable<ProductItemResponse> GetProducts()
        {
            return products;
        }
        public ProductItemResponse? GetProduct(int id)
        {

            return products.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<ProductItemResponse> Search(string name) => products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        public int CreateNewProduct(CreateProductRequest request)
        {
            var id = products.Last().Id + 1;
            var productResponse = new ProductItemResponse(id, request.Name, request.Price, request.Description);
            products.Add(productResponse);
            return id;
        }

    }
}

