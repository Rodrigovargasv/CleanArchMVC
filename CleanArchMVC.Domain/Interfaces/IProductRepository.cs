using CleanArchMVC.Domain.Entites;

namespace CleanArchMVC.Domain.Interfaces
{
    public interface IProductRepository
    {

        // Basic methods for performing CRUD
        // Métodos básico para a realização de CRUD

        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product> GetByIdProductAsync(int? id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<Product> DeleteProductAsync(Product product);
    }
}
