using CleanArchMVC.Application.DTOs;

namespace CleanArchMVC.Application.Interfaces
{
    public interface ICategoryService
    {
        // Contracts that will be implemented in the service folder
        // Contratos que serão implementados na pasta serviço

        Task<IEnumerable<CategoryDTO>> GetAllCategoryDTOsAsync();
        Task<CategoryDTO> GetByIdCategoryDTOAsync(int? id);
        Task CreateCategoryDTOAsync(CategoryDTO categoryDTO);
        Task UpdateCategoryDTOAsync(CategoryDTO categoryDTO);
        Task DeleteCategoryDTOAsync(int? id);
    }
}
