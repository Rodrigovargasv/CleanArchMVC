using CleanArchMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategoryDTOsAsync();
        Task<CategoryDTO> GetByIdCategoryDTOAsync(int? id);
        Task<CategoryDTO> CreateCategoryDTO(CategoryDTO categoryDTO);
        Task<CategoryDTO> UpdateCategoryDTOAsync(CategoryDTO categoryDTO);
        Task<CategoryDTO> DeleteCategoryDTOAsync(int? id);
    }
}
