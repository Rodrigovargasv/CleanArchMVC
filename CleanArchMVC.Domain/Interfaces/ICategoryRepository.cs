using CleanArchMVC.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Interfaces
{
    public interface ICategoryRepository
    {

        // Basic methods for performing CRUD
        // Métodos básicos para a realização de CRUD

        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Category> GetCategoryByIdAsync(int? id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<Category> DeleteCategoryAsync(Category category);
    }
}
