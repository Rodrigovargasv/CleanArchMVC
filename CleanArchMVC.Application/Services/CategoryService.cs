using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entites;
using CleanArchMVC.Domain.Interfaces;

namespace CleanArchMVC.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        { 
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task CreateCategoryDTOAsync(CategoryDTO categoryDTO)
        {
            var createdCategory = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.CreateCategoryAsync(createdCategory);
            
        }

        #region Implementação de metados de busca, atualização e deleção de dados.
        public async Task DeleteCategoryDTOAsync(int? id)
        {
            var categoryId = _categoryRepository.GetCategoryByIdAsync(id).Result;
            await _categoryRepository.DeleteCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoryDTOsAsync()
        {
            var getAllCategory = await _categoryRepository.GetAllCategoryAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(getAllCategory); 
        }

        public async Task<CategoryDTO> GetByIdCategoryDTOAsync(int? id)
        {
            var getByIdCategory = await _categoryRepository.GetCategoryByIdAsync(id);
            return _mapper.Map<CategoryDTO>(getByIdCategory);
        }

        public async Task UpdateCategoryDTOAsync(CategoryDTO categoryDTO)
        {
           var updateCategory = _mapper.Map<Category>(categoryDTO);
           await _categoryRepository.UpdateCategoryAsync(updateCategory);
        }
        #endregion
    }
}
