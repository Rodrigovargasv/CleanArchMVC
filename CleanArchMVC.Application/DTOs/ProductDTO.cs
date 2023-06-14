
using CleanArchMVC.Domain.Entites;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMVC.Application.DTOs
{
    public class ProductDTO
    {
        public int id { get; set; }

        [Required(ErrorMessage = "The Name field is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; private set; }

        [Required]
        [MinLength(5, ErrorMessage = "The description field must be greater than 5 characters")]
        [MaxLength(200)]
        public string Description { get; private set; }

        [Required(ErrorMessage = "The Price field is required")]
        [MinLength(0, ErrorMessage = "The value of the product cannot be less than 0")]
        public decimal Price { get; private set; }

        [Required(ErrorMessage = "The Stock field is required")]
        public int Stock { get; private set; }

        public Category Category;
        public int CategoryId { get; set; }
    }
}
