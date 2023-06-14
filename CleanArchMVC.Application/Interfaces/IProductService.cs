using CleanArchMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductDTOsAsync();
        Task<ProductDTO> GetByIdProductDTOAsync(int? id);
        Task<ProductDTO> CreateProductDTOAync(ProductDTO productDTO);
        Task<ProductDTO> UpdateProductDTOAsync(ProductDTO productDTO);
        Task<ProductDTO> DeleteProductDTOAsync(int? id);
    }
}
