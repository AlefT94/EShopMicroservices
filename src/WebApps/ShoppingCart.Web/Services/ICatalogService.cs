namespace ShoppingCart.Web.Services;

public interface ICatalogService
{
    Task<GetProductsResponse> GetProducts(int? pageNumber = 1, int? pagesize = 10);
    Task<GetProductByIdResponse> GetProduct(Guid id);
    Task<GetProductByCategoryResponse> GetProductsByCategory(string category);
}
