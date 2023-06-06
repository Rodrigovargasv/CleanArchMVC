using CleanArchMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entites
{
    public sealed class Product : EntityBase
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal? Price { get; private set; }

        public int? Stock { get; private set; }

        public Category Category;
        public int? CategoryId { get;  set; }

        // Constructor
        public Product(string name, string description, decimal price, int stock) 
        {
            ValidationDomain(name, description, price, stock);
        }
        public Product(int id, string name, string description, decimal price, int stock)
        {
            DomainExceptionValidation.When(id < 0,
                "The id not can be 0");
            ValidationDomain(name, description, price, stock);
        }


        // Method to update the domain
        // Método para atualizar o domain
        public void Update(string name, string description, decimal price, int stock)
        {
            ValidationDomain(name, description, price, stock);
        }


        // Method to accomplish the domain validation
        // Método para realizar a validação do dominínio
        public void ValidationDomain(string name, string description, decimal price, int stock)
        {

            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "The Name field is required");
            DomainExceptionValidation.When(name.Length < 3,
                "The name field must be greater than 3 characters");
            DomainExceptionValidation.When(description.Length < 5,
               "The description field must be greater than 5 characters");
            DomainExceptionValidation.When(price < 0,
                "The value of the product cannot be less than 0");
            DomainExceptionValidation.When(string.IsNullOrEmpty(price.ToString()),
                "The Price field is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(stock.ToString()),
                "The Price field is required");

            Name= name;
            Description= description;
            Price= price;
            Stock= stock;

        }
    }
}
