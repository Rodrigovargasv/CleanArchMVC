using CleanArchMVC.Domain.Entites;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMVC.Application.Products.Commands
{
    public abstract class ProductCommand : IRequest<Product>
    {

        public string Name { get; private set; }
      
        public string Description { get; private set; }
     
        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public int CategoryId { get; set; }
    }
}
