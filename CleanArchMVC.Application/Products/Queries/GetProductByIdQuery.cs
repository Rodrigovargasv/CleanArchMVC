using CleanArchMVC.Domain.Entites;
using MediatR;

namespace CleanArchMVC.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }

        public GetProductByIdQuery (int id)
        {
            Id = id;
        }   
    }
}
