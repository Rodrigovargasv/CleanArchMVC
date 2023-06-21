using CleanArchMVC.Application.Products.Queries;
using CleanArchMVC.Domain.Entites;
using CleanArchMVC.Domain.Interfaces;
using MediatR;

namespace CleanArchMVC.Application.Products.Handlers
{
    public class GetProudctByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _repository;

        public GetProudctByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            => await _repository.GetByIdProductAsync(request.Id);
            
    }
}
