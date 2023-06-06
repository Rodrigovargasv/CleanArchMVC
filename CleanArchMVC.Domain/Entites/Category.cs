using CleanArchMVC.Domain.Validation;

namespace CleanArchMVC.Domain.Entites
{
    public sealed class Category : EntityBase
    {
        public string Name { get; private set; }

        public ICollection<Product> Products { get;}


        // Constructor
        public Category(string name)
        {
            ValidationDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "The id not can be 0");
            ValidationDomain(name);
        }

        // Method to update the domain
        // Método para atualizar o domain
        public void Update(string name)
        {
            ValidationDomain(name);
        }

        // Method to accomplish the domain validation
        // Método para realizar a validação do dominínio
        public void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
               "The Name field is required");
            DomainExceptionValidation.When(name.Length < 3,
                "The name field must be greater than 3 characters");

            Name = name;
            
        }

    }
}
