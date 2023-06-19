using CleanArchMVC.Application.DTOs;


namespace CleanArchMVC.Application.Interfaces
{
    public interface IProductService
    {
        // Contracts that will be implemented in the service folder
        // Contratos que serão implementados na pasta serviço

        Task<IEnumerable<ProductDTO>> GetAllProductDTOsAsync();
        Task<CategoryDTO> GetByIdProductDTOAsync(int? id);
        Task CreateProductDTOAync(ProductDTO productDTO);
        Task UpdateProductDTOAsync(ProductDTO productDTO);
        Task DeleteProductDTOAsync(int? id);
    }
}
