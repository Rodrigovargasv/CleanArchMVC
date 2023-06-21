using CleanArchMVC.Domain.Entites;
using MediatR;


namespace CleanArchMVC.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
