using CleanArchMVC.Domain.Entites;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CleanArchMVC.Application.DTOs
{
    public class CategoryDTO
    {
        public int id { get; set; }

        [Required(ErrorMessage = "The Name field is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get;  set; }


    }
}
