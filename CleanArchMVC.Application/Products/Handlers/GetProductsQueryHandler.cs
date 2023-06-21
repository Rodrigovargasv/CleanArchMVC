using CleanArchMVC.Application.Products.Queries;
using CleanArchMVC.Domain.Entites;
using CleanArchMVC.Domain.Interfaces;
using MediatR;

namespace CleanArchMVC.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {

        private readonly IProductRepository _repository;

        public GetProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            => await _repository.GetAllProductAsync();
    }
}
