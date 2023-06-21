using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Domain.Entites;
using CleanArchMVC.Domain.Interfaces;
using MediatR;

namespace CleanArchMVC.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductUpdateCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdProductAsync(request.Id);
            

            if (product == null)
            {
                throw new ApplicationException($"Error could  not be found.");
            }
            else
            {
                product.Update(request.Name, request.Description, request.Price, request.Stock, request.CategoryId);
                return await _repository.UpdateProductAsync(product);
            }
        }
    }
}
