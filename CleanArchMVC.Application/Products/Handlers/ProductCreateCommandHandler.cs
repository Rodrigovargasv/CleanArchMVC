using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Domain.Entites;
using CleanArchMVC.Domain.Interfaces;
using MediatR;


namespace CleanArchMVC.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Stock);

            if (product == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                product.CategoryId = request.CategoryId;
                return await _productRepository.CreateProductAsync(product);
            }
        }
    }
}
