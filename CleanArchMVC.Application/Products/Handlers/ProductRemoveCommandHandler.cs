using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Domain.Entites;
using CleanArchMVC.Domain.Interfaces;


namespace CleanArchMVC.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler
    {
        private readonly IProductRepository _repository;

        public ProductRemoveCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdProductAsync(request.Id);


            if (product == null)
            {
                throw new ApplicationException($"Error could  not be found.");
            }
            else
            {
                var result = await _repository.DeleteProductAsync(product);
                return result;
            }
        }
    }
}
