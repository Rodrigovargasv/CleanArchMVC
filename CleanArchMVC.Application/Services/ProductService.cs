using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entites;
using CleanArchMVC.Domain.Interfaces;

namespace CleanArchMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        #region Implementação de metados de busca, atualização e deleção de dados.
        public async Task CreateProductDTOAync(ProductDTO productDTO)
        {
            var createdProduct = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateProductAsync(createdProduct);
        }

        public async Task DeleteProductDTOAsync(int? id)
        {
            var deleteProduct = _mapper.Map<Product>(id);   
            await _productRepository.DeleteProductAsync(deleteProduct);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductDTOsAsync()
        {
            var getAllProducts = await _productRepository.GetAllProductAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(getAllProducts);
        }

        public async Task<CategoryDTO> GetByIdProductDTOAsync(int? id)
        {
            var getByIdProduct = await _productRepository.GetByIdProductAsync(id);
            return _mapper.Map<CategoryDTO>(getByIdProduct);
        }

        public async Task UpdateProductDTOAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _productRepository.UpdateProductAsync(product);
        }
        #endregion
    }
}
