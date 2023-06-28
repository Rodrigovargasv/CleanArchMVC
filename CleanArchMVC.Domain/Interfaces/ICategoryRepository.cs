using CleanArchMVC.Domain.Entites;

namespace CleanArchMVC.Domain.Interfaces
{
    public interface ICategoryRepository
    {

        // Basic methods for performing CRUD
        // Métodos básico para a realização de CRUD

        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Category> GetCategoryByIdAsync(int? id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<Category> DeleteCategoryAsync(Category category);
    }
}
