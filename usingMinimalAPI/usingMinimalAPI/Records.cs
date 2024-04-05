namespace usingMinimalAPI
{
    public record ProductItemResponse(int Id, string Name, decimal Price, string? Description);
    public record CreateProductRequest(string Name, decimal Price, string? Description);
}
