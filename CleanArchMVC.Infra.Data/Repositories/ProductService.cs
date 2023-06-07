using CleanArchMVC.Domain.Entites;
using CleanArchMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Infra.Data.Repositories
{
    public class ProductService : IProductRepository
    {
        public Task<Product> CreateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdProductAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
